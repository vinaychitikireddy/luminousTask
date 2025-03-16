# Use a base image
FROM openjdk:17-jdk

# Set working directory
WORKDIR /app

# Copy built artifacts from Jenkins workspace to container
COPY target/myapp.jar myapp.jar

# Expose port (if it's a web app)
EXPOSE 8080

# Run the application
CMD ["java", "-jar", "myapp.jar"]
