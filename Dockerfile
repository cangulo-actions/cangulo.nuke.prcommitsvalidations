FROM mcr.microsoft.com/dotnet/runtime:5.0

# better to add the dynamic labels as 
#   * org.opencontainers.image.created
#   * org.opencontainers.image.version

LABEL \
    org.opencontainers.image.title="PR Commits Validator"                                                                               \
    org.opencontainers.image.description="Docker image to execute the project cangulo.nuke.prcommitsvalidations as a GitHub action."    \
    org.opencontainers.image.source="https://github.com/cangulo-actions/cangulo.nuke.prcommitsvalidations" \
    org.opencontainers.image.url="https://hub.docker.com/r/cangulomascarell/nuke.prcommitsvalidations"     \
    org.opencontainers.image.documentation="https://github.com/cangulo-actions/cangulo.nuke.prcommitsvalidations"    \
    org.opencontainers.image.authors="@cangulo"

# source doce https://github.com/cangulo/cangulo.nuke.prcommitsvalidations

RUN echo "####  workspace $GITHUB_WORKSPACE"


COPY ./app ./

ENTRYPOINT ["dotnet", "/cangulo.nuke.prcommitsvalidations.dll", "--root","."]
