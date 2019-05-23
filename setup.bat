start .paket/paket.exe install
start .paket/paket.exe update
git submodule update --init --recursive
git submodule update --recursive --remote
dotnet nuget locals all --clear
dotnet restore src/Main/Main.fsproj
dotnet restore src/Renderer/Renderer.fsproj
dotnet restore src/RendererAboutWindow/RendererAboutWindow.fsproj
yarn install
