FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app

# Install Matlab Runtime
RUN apt-get update -q \
    && apt-get install curl wget unzip -y \
    && curl https://ssd.mathworks.com/supportfiles/downloads/R2022a/Release/0/deployment_files/installer/complete/glnxa64/MATLAB_Runtime_R2022a_glnxa64.zip -o  MATLAB_Runtime_R2022a_glnxa64.zip\
    && unzip ./MATLAB_Runtime_R2022a_glnxa64.zip -d matlabruntime \
    && ./matlabruntime/install -destinationFolder /opt/mcr -mode silent -agreeToLicense yes

ENV LD_LIBRARY_PATH /opt/mcr/v912/runtime/glnxa64:/opt/mcr/v912/bin/glnxa64:/opt/mcr/v912/sys/os/glnxa64:/opt/mcr/v912/extern/bin/glnxa64

# Remove unnecessary files
RUN rm MATLAB_Runtime_R2022a_glnxa64.zip && \
    rm -r matlabruntime

RUN apt-get update && apt-get install --no-install-recommends -y \
libasound2 \
libc6 \
libcairo-gobject2 \
libcairo2 \
libcap2 \
libcups2 \
libdbus-1-3 \
libdrm2 \
libfontconfig1 \
libgbm1 \
libgdk-pixbuf2.0-0 \
libglib2.0-0 \
libgomp1 \
libgstreamer-plugins-base1.0-0 \
libgstreamer1.0-0 \
libgtk-3-0 \
libmysqlcppconn7v5 \
libnspr4 \
libnss3 \
libodbc1 \
libpam0g \
libpango-1.0-0 \
libpangocairo-1.0-0 \
libpangoft2-1.0-0 \
libpython2.7 \
libsm6 \
libsndfile1 \
libuuid1 \
libx11-6 \
libx11-xcb1 \
libxcb-dri3-0 \
libxcb1 \
libxcomposite1 \
libxcursor1 \
libxdamage1 \
libxext6 \
libxfixes3 \
libxft2 \
libxi6 \
libxinerama1 \
libxrandr2 \
libxrender1 \
libxt6 \
libxtst6 \
libxxf86vm1 \
zlib1g \
&& apt-get clean && apt-get -y autoremove && rm -rf /var/lib/apt/lists/*

COPY ./src /app/src
RUN dotnet publish "/app/src/MyDotNet5App.csproj" -c Release -o /app/publish --runtime linux-x64 --self-contained true
ENTRYPOINT ["/app/publish/MyDotNet5App", "3"]

# FROM base AS build
# COPY ["bin/Release/netcoreapp2.1/linux-x64/publish/", "publish/"]
# FROM base AS build
# WORKDIR /src
# COPY ["MyDotNetCoreApp.csproj", "MyDotNetCoreApp/"]
# RUN dotnet restore "MyDotNetCoreApp/MyDotNetCoreApp.csproj"
# COPY . .
# WORKDIR "/src/MyDotNetCoreApp"
# RUN dotnet build "MyDotNetCoreApp.csproj" -c Release -o /app

# FROM build AS publish
# RUN dotnet publish "MyDotNetCoreApp.csproj" -c Release -o /app --runtime linux-x64 --self-contained true

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app .
# ENTRYPOINT ["dotnet", "MyMagicApp.dll"]dock