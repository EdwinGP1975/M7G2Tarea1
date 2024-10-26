pipeline {
    agent any

    parameters {

        separator(name: "GITHUB_CONFIGURATION", sectionHeader: "GITHUB CONFIGURATION");
        string(name: 'GITHUB_URL', defaultValue: "https://github.com/chuflay29/M7G2Tarea1.git", description: 'Github url project');
        string(name: 'GITHUB_BRANCH', defaultValue: 'Api2', description: 'Github branch name');

        separator(name: "BUILD_CONFIGURATION", sectionHeader: "BUILD CONFIGURATION");
        string(name: 'DOTNET_VERSION', defaultValue: "8.0", description: '.NET version');
        string(name: 'SOLUTION_NAME', defaultValue: "M7Tarea1.sln", description: '.NET Solution');
        string(name: 'API_PROJECT_NAME', defaultValue: "M7Tarea1.Server\\M7Tarea1.Server.csproj", description: 'API project .NET');
        string(name: 'API_BUILD_PATH', defaultValue: "M7Tarea1.Server\\bin\\Release\\net8.0", description: 'API Artifact path');
        string(name: 'API_SITE_NAME', defaultValue: "ApiVentas", description: 'Api site name');
        string(name: 'API_SITE_PATH', defaultValue: "C:\\inetpub\\wwwroot\\ApiVentas", description: 'Api site Path');
        string(name: 'MSBUILD_PATH', defaultValue: "C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\MSBuild\\Current\\Bin\\MSBuild.exe", description: "Msbuild path");
    }

    stages {
        stage('Checkout Project') {
            steps {
                git(url: "${GITHUB_URL}", branch: "${GITHUB_BRANCH}")
            }
        }

        stage('Restore Nuggets') {
            steps {
                script {
                    String command = "& \"" + "${MSBUILD_PATH}" + "\" -t:Restore" + " \"" + "${WORKSPACE}" + "\\" + "${API_PROJECT_NAME}" + "\"";
                    println(command);

                    String output = powershell(returnStdout:true, script:command).trim();
                    println(output);
                }
            }
        }

        stage('Build API Project') {
            steps {
                script {
                    //String command = "& \"" + "${MSBUILD_PATH}" + "\" -p:TargetFrameworkVersion=v" + "${DOTNET_VERSION}" + " \"" + "${WORKSPACE}" + "\\" + "${API_PROJECT_NAME}" + "\"";
                    String command = "& \"" + "${MSBUILD_PATH}" + "\" -t:Build -p:TargetFrameworkVersion=v" + "${DOTNET_VERSION}" + " -p:Configuration=Release" + " \"" + "${WORKSPACE}" + "\\" + "${API_PROJECT_NAME}" + "\"";
                    println(command);

                    String output = powershell(returnStdout:true, script:command).trim();
                    println(output);
                }
            }
        }


        stage('Deploy API Project') {
            steps {
                script {


                    String command = "Import-Module WebAdministration";
                    println(command);
                    String output = powershell(returnStdout:true, script:command).trim();
                    println(output);
                    
                    command = "Stop-WebSite -Name " + "\"" + "${API_SITE_NAME}" + "\"";
                    println(command);
                    output = powershell(returnStdout:true, script:command).trim();
                    println(output);

                    command = "Remove-Item -Path " + "\"" + "${API_SITE_PATH}" + "\"" + " -Recurse -Force -Exclude web.config";
                    println(command);
                    output = powershell(returnStdout:true, script:command).trim();
                    println(output);

                    command = "Copy-Item -Path " + " \"" + "${WORKSPACE}" + "\\" + "${API_BUILD_PATH}" + "\\*" + "\"" + " -Destination "+ "\"" + "${API_SITE_PATH}" + "\"" + " -Recurse -Container";
                    println(command);
                    output = powershell(returnStdout:true, script:command).trim();
                    println(output);

                    command = "Start-WebSite -Name " + "\"" + "${API_SITE_NAME}" + "\"";
                    println(command);
                    output = powershell(returnStdout:true, script:command).trim();
                    println(output);
                }
            }
        }
    }

}