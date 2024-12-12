## Problem  

```
Unhandled exception. System.DllNotFoundException: Unable to load shared library 'lua54' or one of its dependencies. In order to help diagnose loading problems, consider using a tool like strace. If you're using glibc, consider setting the LD_DEBUG environment variable:
/usr/share/dotnet/shared/Microsoft.NETCore.App/8.0.11/lua54.so: cannot open shared object file: No such file or directory
/app/lua54.so: cannot open shared object file: No such file or directory
/usr/share/dotnet/shared/Microsoft.NETCore.App/8.0.11/liblua54.so: cannot open shared object file: No such file or directory
/app/liblua54.so: cannot open shared object file: No such file or directory
/usr/share/dotnet/shared/Microsoft.NETCore.App/8.0.11/lua54: cannot open shared object file: No such file or directory
/app/lua54: cannot open shared object file: No such file or directory
/usr/share/dotnet/shared/Microsoft.NETCore.App/8.0.11/liblua54: cannot open shared object file: No such file or directory
/app/liblua54: cannot open shared object file: No such file or directory

   at KeraLua.NativeMethods.luaL_newstate()
   at KeraLua.Lua..ctor(Boolean openLibs)
   at NLua.Lua..ctor(Boolean openLibs)
```

## References 

- https://github.com/NLua/NLua/issues/400
- https://stackoverflow.com/questions/20848275/compiling-lua-create-so-files

## KeraLua

```
cd ~
wget https://dot.net/v1/dotnet-install.sh
bash ./dotnet-install.sh --channel 8.0
export PATH="$HOME/.dotnet/:$PATH"
dotnet --version

git clone https://github.com/NLua/KeraLua
cd KeraLua
git submodule update --init --recursive
# comment signing from build/net8.0/KeraLua.net.8.0.csproj
dotnet restore KeraLua.net8.0.sln
dotnet publish -c Release -r linux-arm64 -o out -verbosity:diag --self-contained true KeraLua.net8.0.sln

dotnet test out/KeraLuaTest.net8.0.dll
# Passed!  - Failed:     0, Passed:    24, Skipped:     0, Total:    24, Duration: 8 s - KeraLuaTest.net8.0.dll (net8.0)
```

## Project

### Build

```
cd ~
git clone https://github.com/ladder99/NLuaARM
cd NLuaARM

dotnet restore
dotnet publish -c Release -o out

cp ~/KeraLua/out/liblua54.so ./out

dotnet out/NLuaARM.dll
```

### Docker Build

```
cd ~
git clone https://github.com/ladder99/NLuaARM
cd NLuaARM

docker build -f Dockerfile --tag=nluaarm:latest .

docker run nluaarm:latest
```

