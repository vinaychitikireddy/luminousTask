pipeline {
    agent any
environment {
        IMAGE_NAME = 'myapp:latest'
        DOCKER_HUB_USER = 'mydockerhubuser'
        DOCKER_HUB_REPO = 'myrepo'
    }

    stages {
        stage('Build') {
            steps {
                sh 'mvn clean package'  // Adjust for your build tool
            }
        }

        stage('Build Docker Image') {
            steps {
                sh "docker build -t $IMAGE_NAME ."
            }
        }

        stage('Push Docker Image') {
            steps {
                withDockerRegistry([credentialsId: 'docker-hub-credentials', url: '']) {
                    sh "docker tag $IMAGE_NAME $DOCKER_HUB_USER/$DOCKER_HUB_REPO:$BUILD_NUMBER"
                    sh "docker push $DOCKER_HUB_USER/$DOCKER_HUB_REPO:$BUILD_NUMBER"
                }
            }
        }
    }
    stages {
        stage('Checkout Code') {
            steps {
                git branch: 'master', url: 'https://github.com/vinaychitikireddy/luminousTask.git'
            }
        }

        stage('Build') {
            steps {
                echo 'Building the application...'
                bat 'echo Build step completed!'  // Replace with actual build command
            }
        }

        stage('Test') {
            steps {
                echo 'Running tests...'
                bat 'echo Test step completed!'  // Replace with actual test command
            }
        }

        stage('Deploy') {
            steps {
                echo 'Deploying application...'
                bat 'echo Deployment step completed!'  // Replace with actual deploy command
            }
        }
    }
}
