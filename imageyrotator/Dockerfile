FROM ubuntu:18.04

RUN dpkg --add-architecture i386 \
    && apt-get update \
    && apt-get install -qfy --install-recommends \
        software-properties-common \
        gnupg2 \
        wget \
        xvfb \
        cabextract \
    && wget -nv https://dl.winehq.org/wine-builds/winehq.key \
    && apt-key add winehq.key \
    && apt-add-repository 'deb https://dl.winehq.org/wine-builds/ubuntu/ bionic main' \
    && add-apt-repository ppa:cybermax-dexter/sdl2-backport \
    && apt-get install -qfy --install-recommends \
        winehq-stable \
        winbind \
    && apt-get -y clean \
    && rm -rf \
      /var/lib/apt/lists/* \
      /usr/share/doc \
      /usr/share/doc-base \
      /usr/share/man \
      /usr/share/locale \
      /usr/share/zoneinfo

ENV WINEDEBUG=fixme-all
ENV WINEPREFIX=/root/.net
ENV WINEARCH=win64

RUN winecfg \
    && wget https://raw.githubusercontent.com/Winetricks/winetricks/master/src/winetricks \
    -O /usr/local/bin/winetricks \
    && chmod +x /usr/local/bin/winetricks \
    && apt-get -y clean \
    && rm -rf \
      /var/lib/apt/lists/* \
      /usr/share/doc \
      /usr/share/doc-base \
      /usr/share/man \
      /usr/share/locale \
      /usr/share/zoneinfo \
    && wineboot -u && winetricks -q dotnet472

WORKDIR /root/.net/drive_c/imageyrotator/

COPY /publish/ /root/.net/drive_c/imageyrotator/

ENTRYPOINT ["wine", "ImageYRotator.exe"]