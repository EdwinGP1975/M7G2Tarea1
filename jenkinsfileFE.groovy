pipeline {
    agent any

    parameters {

        separator(name: "GITHUB_CONFIGURATION", sectionHeader: "GITHUB CONFIGURATION");
        string(name: 'GITHUB_URL', defaultValue: "https://github.com/chuflay29/M7G2Tarea1.git", description: 'Github url project');
        string(name: 'GITHUB_BRANCH', defaultValue: 'Api2', description: 'Github branch name');

        separator(name: "BUILD_CONFIGURATION", sectionHeader: "BUILD CONFIGURATION");
        string(name: 'SOLUTION_NAME', defaultValue: "M7Tarea1.sln", description: '.NET Solution');
        string(name: 'ANGULAR_PROJECT_FOLDER', defaultValue: "m7tarea1.client", description: 'Angular Web project folder');
        string(name: 'ANGULAR_PROJECT_NAME', defaultValue: "m7tarea1.client.esproj", description: 'Angular Web project name');
        string(name: 'ANGULAR_BUILD_PATH', defaultValue: "m7tarea1.client\\dist\\m7tarea1.client", description: 'Angular Web project build path');
        string(name: 'ANGULAR_SITE_NAME', defaultValue: "WebVentas", description: 'Angular Web project site name');
        string(name: 'ANGULAR_SITE_PATH', defaultValue: "C:\\inetpub\\wwwroot\\WebVentas", description: 'Angular Web project site path');
        string(name: 'MSBUILD_PATH', defaultValue: "C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\MSBuild\\Current\\Bin\\MSBuild.exe", description: "Msbuild path");
        string(name: 'NODEJS_PATH', defaultValue: "C:\\Users\\User\\AppData\\Roaming\\nvm\\v20.13.1", description: 'NodeJS path');
    }

    stages {
        stage('Checkout Project') {
            steps {
                git(url: "${GITHUB_URL}", branch: "${GITHUB_BRANCH}")
            }
        }

        stage('Build Web Project') {
            steps {
                script {
                    String command = "& \"" + "${MSBUILD_PATH}" + "\" -t:Build -p:Configuration=Release" + " \"" + "${WORKSPACE}" + "\\" + "${ANGULAR_PROJECT_FOLDER}" + "\\" + "${ANGULAR_PROJECT_NAME}" + "\"";
                    println(command);

                    String output = powershell(returnStdout:true, script:command).trim();
                    println(output);

                    command = "& Set-Location -Path " + "\"" +"${WORKSPACE}" + "\\" + "${ANGULAR_PROJECT_FOLDER}" + "\"" + ";" + " npm install ";
                    println(command);

                    output = powershell(returnStdout:true, script:command).trim();
                    println(output);

                    command = "& Set-Location -Path " + "\"" +"${WORKSPACE}" + "\\" + "${ANGULAR_PROJECT_FOLDER}" + "\"" + ";" + " ng build --configuration=production";
                    println(command);

                    output = powershell(returnStdout:true, script:command).trim();
                    println(output);
                }
            }
        }
        
        stage('Build Solution') {
            steps {
                script {
                    String command = "";
                    println(command);

                    String output = powershell(returnStdout:true, script:command).trim();
                    println(output);
                }
            }
        }

        stage('Deploy Web Project') {
            steps {
                script {


                    String command = "Import-Module WebAdministration";
                    println(command);
                    String output = powershell(returnStdout:true, script:command).trim();
                    println(output);
                    
                    command = "Stop-WebSite -Name " + "\"" + "${ANGULAR_SITE_NAME}" + "\"";
                    println(command);
                    output = powershell(returnStdout:true, script:command).trim();
                    println(output);

                    command = "Remove-Item -Path " + "\"" + "${ANGULAR_SITE_PATH}" + "\"" + " -Recurse -Force -Exclude web.config";
                    println(command);
                    output = powershell(returnStdout:true, script:command).trim();
                    println(output);

                    command = "Copy-Item -Path " + " \"" + "${WORKSPACE}" + "\\" + "${ANGULAR_BUILD_PATH}" + "\\*" + "\"" + " -Destination "+ "\"" + "${ANGULAR_SITE_PATH}" + "\"" + " -Exclude browser";
                    println(command);
                    output = powershell(returnStdout:true, script:command).trim();
                    println(output);

                    command = "Copy-Item -Path " + " \"" + "${WORKSPACE}" + "\\" + "${ANGULAR_BUILD_PATH}" + "\\browser\\*" + "\"" + " -Destination "+ "\"" + "${ANGULAR_SITE_PATH}" + "\"";
                    println(command);
                    output = powershell(returnStdout:true, script:command).trim();
                    println(output);

                    command = "Start-WebSite -Name " + "\"" + "${ANGULAR_SITE_NAME}" + "\"";
                    println(command);
                    output = powershell(returnStdout:true, script:command).trim();
                    println(output);
                }
            }
        }
    }

}