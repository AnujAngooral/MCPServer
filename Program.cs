// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Net.Http.Json;
using System.Text.Json;

var builder = Host.CreateEmptyApplicationBuilder(settings: null);
builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();

await builder.Build().RunAsync();


[McpServerToolType]
public static class StudentTool
{
    private static readonly HttpClient _httpClient = new HttpClient 
    { 
        BaseAddress = new Uri("http://localhost:5033/") 
    };

    [McpServerTool, Description("Get all students from the API")]
    public static async Task<List<Student>> GetStudents()
    {
        var response = await _httpClient.GetFromJsonAsync<List<Student>>("Student");
        return response ?? new List<Student>();
    }

    [McpServerTool, Description("Get a student by ID")]
    public static async Task<Student?> GetStudent(int id)
    {
        return await _httpClient.GetFromJsonAsync<Student>($"Student/{id}");
    }

    [McpServerTool, Description("Create a new student")]
    public static async Task<Student> CreateStudent(Student student)
    {
        var response = await _httpClient.PostAsJsonAsync("Student", student);
        return await response.Content.ReadFromJsonAsync<Student>();
    }

    [McpServerTool, Description("Update an existing student")]
    public static async Task<Student> UpdateStudent(Student student)
    {
        var response = await _httpClient.PutAsJsonAsync($"Student/{student.Id}", student);
        return await response.Content.ReadFromJsonAsync<Student>();
    }

    [McpServerTool, Description("Delete a student by ID")]
    public static async Task<bool> DeleteStudent(int id)
    {
        var response = await _httpClient.DeleteAsync($"Student/{id}");
        return response.IsSuccessStatusCode;
    }
}

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }    
    public int Id { get; set; }
    public string Address { get; set; }
}

