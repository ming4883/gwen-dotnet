#!/bin/bash
BASEDIR=$(dirname $0)
cd $BASEDIR

clear
export css_nuget=./
mono ./cscs.exe App
