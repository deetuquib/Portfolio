# Flask and Docker

This lab borrows heavily on https://www.freecodecamp.org/news/how-to-dockerize-a-flask-app/

With Docker, you can now easily ship, test, and deploy your code quickly while maintaining full control over your infrastructure. It significantly reduces how long it takes to get from writing code to running it in production.

This lab will show you how to make a basic Docker image and run it as a container. For the demonstration, we'll use Flask as our web framework and Docker for image creation and containerization. You'll also learn a few Docker commands that are commonly used.

## What is Docker?

Docker is a tool that makes it easier to create, deploy, and run applications using containers.

A **docker container** is a collection of dependencies and code organized as software that enables applications to run quickly and efficiently in a range of computing environments.

A **docker image**, on the other hand, is a blueprint that specifies how to run an application. In order for Docker to build images automatically, a set of instructions must be stored in a special file known as a **Dockerfile**.

The instructions in this file are executed by the user on the command line interface in order to create an image. (Source: [docker.com](https://www.docker.com/resources/what-container))

![docker-illustration-2](https://www.freecodecamp.org/news/content/images/2021/11/docker-illustration-2.png)

## How to Set Up the Project

### Basic directory structure

After completing the following steps, our application directory structure will look like this:

**FlaskDocker**
├── app.py
├── Dockerfile
├── requirements.txt

### Create app.py

Let's add the following lines of code to our **app.py**

```
cd ~
mkdir FlaskDocker
cd FlaskDocker
nano app.py
```

Cut and paste the following code then save the file and exit

```python
from flask import Flask
app = Flask(__name__)

@app.route('/')
def hello_world():
    return '<h1>Hello from Flask & Docker -- CST8254 Winter 2022</h1>'

if __name__ == "__main__":
    app.run(debug=True)
```

Now, run

```
 python3 app.py
```

You should get an output like this

```bash
 * Serving Flask app "app" (lazy loading)
 * Environment: production
   WARNING: This is a development server. Do not use it in a production deployment.
   Use a production WSGI server instead.
 * Debug mode: on
 * Running on http://127.0.0.1:5000/ (Press CTRL+C to quit)
 * Restarting with stat
 * Debugger is active!
 * Debugger PIN: 596-923-515

```

### Create the  requirements.txt

Let's create the requirements.txt file

```
nano requirements.txt
```

Cut and paste the following code then save the file and exit

```
Flask==1.0.2
```

### Create the  Dockerfile

Let's create the Docker File

```
nano DockerFile
```

Cut and paste the following code then save the file and exit

```dockerfile
# syntax=docker/dockerfile:1

FROM python:3.8-slim-buster

WORKDIR /python-docker

COPY requirements.txt requirements.txt
RUN pip3 install -r requirements.txt

COPY . .

CMD [ "python3", "-m" , "flask", "run", "--host=0.0.0.0"]
```

Before we build an image for the application we just created, let's first understand what the lines of code in the Docker file above mean and what role they play.

The below code should be the first line of every Dockerfile – it tells the Docker builder what syntax to use while parsing the Dockerfile and the location of the Docker syntax file. ([Source](https://docs.docker.com/engine/reference/builder/#syntax))

```dockerfile
# syntax=docker/dockerfile:1
```

While it is possible to create our own base images, there is no need to go that far because Docker allows us to inherit existing images. The following line tells Docker which base image to use — in this case, a Python image.

```
FROM python:3.8-slim-buster
```

To keep things organized, we also tell Docker which folder to use for the rest of the operations, so we use a relative path as shown below.

In this case, we're telling Docker to use the same directory and name for the rest of its operations — it's a directory contained within our container image.

```
WORKDIR /python-docker
```

In the fourth and fifth lines, we tell Docker to copy the contents of our requirements.txt file into the container image's requirements.txt file. Then run pip install to install all the dependencies in the same file to be used by the image.

```
COPY requirements.txt requirements.txt
RUN pip3 install -r requirements.txt
```

Continuing with the copying, we now copy the remainder of the files in our local working directory to the directory in the docker image.

```
COPY . .
```

Our image so far has all of the files that are similar to those in our local working directory. Our next task is to assist Docker in understanding how to run this image inside a container.

This line specifically instructs Docker to run our Flask app as a module, as indicated by the "-m" tag. Then it instructs Docker to make the container available externally, such as from our browser, rather than just from within the container. We pass the host port:

```
CMD [ "python3", "-m" , "flask", "run", "--host=0.0.0.0"]
```

Since we had,

```python
if __name__ == "__main__":
    app.run(debug=True)
```

Because we had the "if" statement in our application file, this will be true if we run this module as a standalone program. As a result, it can function as a module imported by another program or as a standalone program, but it will only execute the code in the if statement if run as a program. ([Source](https://stackoverflow.com/a/1973391/12943692))

## How to Build a Docker Image

After that, all that remains is to build our image. Using **`docker build`**, we can now enlist Docker's help in building the image. You can combine the build command with other tags, such as the "--tag" flag, to specify the image name.

```
docker build --tag python-docker .
```

Your output will look like this

```bash
Sending build context to Docker daemon  3.072kB
Step 1/6 : FROM python:3.8-slim-buster
3.8-slim-buster: Pulling from library/python
4c7c9f6f1115: Pull complete 
8662021879a6: Pull complete 
c9b74b0d175e: Pull complete 
1b363e78de4f: Pull complete 
a3462485aa07: Pull complete 
Digest: sha256:0ac2a12df86b01d6a482fd07b62b6ca2afe3355cd520260c7d561c4e5c966cdb
Status: Downloaded newer image for python:3.8-slim-buster
 ---> de6de0a220d6
...
```



### How to run an image as a container

Running an image inside a container is as simple as building one. But before we do so, we'd like to see what other images are available in our environment. To view images from the command line, execute the following:

<SCREENSHOT>

```
docker images
```

</SCREENSHOT>

If the above command finds any images, the output should look something like this:

```bash
REPOSITORY                   TAG                   IMAGE ID       CREATED          SIZE
python-docker                latest                5725e9b7d105   13 seconds ago   112MB
...
```

The docker run command will now be formatted as follows:

```
docker run -d -p 5000:5000 python-docker
```

We can use the following command to see which containers are currently running:

```
docker ps
```

The output is as follows:

```
CONTAINER ID   IMAGE           COMMAND                  CREATED         STATUS         PORTS                    NAMES
a173935297cd   python-docker   "python3 -m flask ru…"   5 minutes ago   Up 5 minutes   0.0.0.0:5000->5000/tcp   happy_wescoff
```

On your laptop, you can now connect to `http://<pi-ip-address>:5000`

![](FlaskDocker.jpg)

To stop the currently running container, execute this command on your PI:

```
docker stop <container-name>
```

Another useful command to have when working with Docker is this one:

```
docker container prune
```

It removes unused resources, freeing up space and keeping your system clean.

