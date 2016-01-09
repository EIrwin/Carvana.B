
FROM mono

MAINTAINER Eric Irwin <eric.irwin@carvana.com>

# Copy source files
RUN mkdir '/home/b'
ADD / /home/b

RUN nuget restore /home/b/Carvana.B.sln &&  xbuild /home/b/Carvana.B.sln

EXPOSE 5678

ENTRYPOINT ["mono", "/home/b/Carvana.B.Gateway/bin/Debug/Carvana.B.Gateway.exe"]