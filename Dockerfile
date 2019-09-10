FROM microsoft/dotnet:2.2-sdk AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
# RUN apt-get update -yq && apt-get upgrade -yq && apt-get install -yq curl git nano
# RUN curl -sL https://deb.nodesource.com/setup_8.x | bash - && apt-get install -yq nodejs build-essential
# RUN npm install -g npm
# RUN npm install
# RUN npm install
# RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime

# Setup NodeJs
RUN apt-get update && \
    apt-get install -y wget && \
    apt-get install -y gnupg2 && \
    wget -qO- https://deb.nodesource.com/setup_8.x | bash - && \
    apt-get install -y build-essential nodejs
# End setup
WORKDIR /app
COPY --from=build-env /app/out .
# CMD dotnet mvc.dll
ENTRYPOINT ["dotnet", "mvc.dll"]

# docker build -t mvc .
# docker images
# docker image rm ea -f
# docker rm -f myapp
# docker run -d -p 8080:80 --name myapp mvc
# docker container ls = docker ps
# docker run -it mvc sh
# ocker run -it --entrypoint /bin/bash mvc