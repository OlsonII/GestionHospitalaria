node {

  stage('Checkout') {
    git url: 'https://github.com/OlsonII/GestionHospitalaria',branch: 'master'
  }
  
  stage ('Restore Nuget') {
    bat "dotnet restore GestionHospitalaria.sln"
  }
  
  stage('Clean') {
    bat 'dotnet clean GestionHospitalaria.sln'
  }
  
  stage('Build') {
    bat 'dotnet build GestionHospitalaria.sln  --configuration Release'
  }

  stage ('Test') {
    bat "dotnet test DomainTest/DomainTest.csproj --logger trx;LogFileName=unit_tests.trx"
    mstest testResultsFile:"**/*.trx", keepLongStdio: true
  }
    

  stage('Publish') {
    bat 'dotnet publish WebApi/WebApi.csproj -c Release -o D:/Proyectos/C#/GestionHospitalaria'
  } 
  
}