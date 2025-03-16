pipeline {
    agent any

    stages {
        stage('Checkout Code') {
            steps {
                git branch: 'main', url: 'https://github.com/vinaychitikireddy/luminousTask.git'
            }
        }

        stage('Build') {
            steps {
                echo 'Building the application...'
                sh 'echo Build step completed!'  // Replace with actual build command
            }
        }

        stage('Test') {
            steps {
                echo 'Running tests...'
                sh 'echo Test step completed!'  // Replace with actual test command
            }
        }

        stage('Deploy') {
            steps {
                echo 'Deploying application...'
                sh 'echo Deployment step completed!'  // Replace with actual deploy command
            }
        }
    }
}
