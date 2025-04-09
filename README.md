# MCPServer

## 🛠 VS Code Configuration Setup

To configure VS Code for running `MCPServer`, follow these steps:

1. Create a folder named `.vscode` in the root directory of the project (if it doesn't already exist).
2. Inside the `.vscode` folder, create a file named `mcp.json`.
3. Add the following content to `mcp.json`:

```json
{
  "inputs": [],
  "servers": {
    "MCPServer": {
      "type": "stdio",
      "command": "dotnet",
      "args": [
        "run",
        "--project",
        "C:\\Users\\UserName\\Repos\\MCPServer\\MCPServer.csproj"
      ]
    }
  }
}