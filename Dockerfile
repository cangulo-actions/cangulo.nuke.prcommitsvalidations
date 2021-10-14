# Container image that runs your code
FROM bash:4.4

# Copies your code file from your action repository to the filesystem path `/` of the container
COPY entrypoint.sh /entrypoint.sh
COPY cangulo.nuke.prcommitsvalidations $GITHUB_WORKSPACE/prValidator

# Code file to execute when the docker container starts up (`entrypoint.sh`)
ENTRYPOINT ["/entrypoint.sh"]