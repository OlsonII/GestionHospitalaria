node {

  stage('Checkout') {
    url: 'https://github.com/OlsonII/GestionHospitalaria',branch: 'master'
  }
  //SignusFinanciero.sln
  stage ('Restore Nuget') {
    bat "dotnet restore GestionHospitalaria.sln -s http://byanugetserver.azurewebsites.net/nuget -s https://api.nuget.org/v3/index.json"
  }
  
  stage('Clean') {
    bat 'dotnet clean GestionHospitalaria.sln'
  }
  
  stage('Build') {
    bat 'dotnet build GestionHospitalaria.sln  --configuration Release'
  }

  stage ('Test') {
    bat "dotnet test GestionHospitalaria/DomainTest/DomainTest.csproj --logger trx;LogFileName=unit_tests.trx"
    mstest testResultsFile:"**/*.trx", keepLongStdio: true
  }
    

  stage('Publish') {
    bat 'dotnet publish GestionHospitalaria/WebApi/WebApi.csproj -c Release -o D:/Proyectos/C#/GestionHospitalaria'
  } 
  
}