```
cd ~
git clone https://github.com/ladder99/NLuaARM
cd NLuaARM/NLuaARM

docker build -f Dockerfile --tag=nluaarm:latest .

docker run nluaarm:latest
```