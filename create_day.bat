set /p project=Welke dag aanmaken?

cd src
dotnet new console -o %project%
cd %project%
dotnet add reference ../shared
cd ../..
dotnet sln add src/%project%
cd test
dotnet add reference ../src/%project%
cd ..