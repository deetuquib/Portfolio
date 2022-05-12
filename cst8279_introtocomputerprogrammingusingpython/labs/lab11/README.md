# README

- Install [Miniconda](https://docs.conda.io/en/latest/miniconda.html)
    ```bash
    # go to the downloads folder
    $ cd ~/Downloads

    # download the latest version for linux
    $ wget https://repo.anaconda.com/miniconda/Miniconda3-latest-Linux-x86_64.sh

    # make the script executable
    $ chmod +x Miniconda3-latest-Linux-x86_64.sh

    # run the installer
    $ ./Miniconda3-latest-Linux-x86_64.sh
    ```
- Follow the instructions on how to initialize `conda`
    ```bash
    # make sure conda is installed and is visible in the $PATH
    $ which conda
    ```
- Create your virtual environment using `conda create`
    ```bash
    # create with python version 3.9
    $ conda create -n cst8279__lab11 python=3.9

    # activate
    $ conda activate cst8279__lab11

    # make sure a different version of python and pip is used!
    (cst8279__lab11) $ which python
    (cst8279__lab11) $ which pip
    ```
- Install requirements using `pip`
    ```bash
    (cst8279__lab11) $ pip install -r requirements.txt
    ```
- Run
    ```bash
    (cst8279__lab11) $ python ./lab11_DianaJean.py
    ```