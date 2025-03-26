# Docker Commands for ChallengeB_App

## Build the Docker Image
```sh
docker build -t challengeb-app .
```
## Run the Container with Volume Mounting
```sh
docker run --rm -v C:/SnappyMob_Coding_Challenge/SnappyMobChallenge/ChallengeB_App/random_object.txt:/app/input/random_object.txt -v C:/SnappyMob_Coding_Challenge/SnappyMobChallenge/ChallengeB_App/output:/app/output challengeb-app /app/input/random_object.txt /app/output/result.txt
```
## View the Result
Check the output folder inside your project directory for result.txt.
