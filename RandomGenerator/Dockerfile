FROM ubuntu:bionic
RUN apt-get update -y
RUN apt-get upgrade -y
RUN apt install wget -y
RUN wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb
RUN dpkg -i packages-microsoft-prod.deb
RUN apt update -y
RUN apt-get install apt-transport-https -y
RUN apt update -y
RUN apt-get -y install dotnet-sdk-2.1
RUN dotnet new -i "Microsoft.Quantum.ProjectTemplates::0.2.1809.701-preview"
RUN apt install libgomp1 -y
WORKDIR /app
COPY *.*s* /
WORKDIR /app
RUN dotnet build
ENTRYPOINT ["dotnet"]
CMD ["run"]