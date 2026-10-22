# QTEGame (wt)

Second prototype developed by Team 8 of NexGen Studios.

## Table of Contents

1. Introduction
1. Vision
1. Goals
1. Mechanics
1. World
1. Interface
1. Audio
1. Resources

## Introduction 

Our prototype is a repeatable minigame based on keyboard input quick-time events that progressively become more challenging to complete.

The game begins by giving the player a short sequence of keys to press, if the player completes it they will move onto the next round, each round will give them a new sequence that is one input longer than the last until the player fails. 

## Vision

Our target player motivations are **Action** and **Mastery**.  
Our vision for this prototype is to create a game based around QTEs that engages and challenges players through ramping difficulty and fast-paced player action. The action and challenge the game provides are created through physical-mechanical difficulty.

## Goals

With this prototype our objective statement is as such:
### Can a simple quick-time event mechanic turn into an engaging ramping challenge that is enjoyable enough to act as a standalone minigame? By testing this concept,  we can prove if this framework of QTE can be ported to other games to provide a new element of action and challenge.

The player experience goal is to make players feel challenged as they try to quickly input the correct keys and complete each round.

## Mechanics

### 1. Input

The main game loop is played using the W, A, S, and D keys, with the Space key being used to restart when the game is ended. Players are tasked with pressing keys in sequentially corresponding to the sequence given on screen. Pressing an incorrect key will momentarily stop the player's ability to input key presses.

### 2. Rounds

The game is structured using a rounds based system, the game progressively getting harder with each round. Each round will generate a random sequence of WASD directional keys for the player to press, the quantity starting at # at the first round and increasing by 1 each round.

## World

Currently, the game exists in a purple void with pixel-style graphics of the keys the player is to press.

## Interface

The key press sequence is shown on screen using sprites of keyboard keys with the corresponding letter on them, the sprites ordered left to right. The interface aside from the QTE sequence is very minimalistic, consisting of a simple white text timer at the top of the screen and more white text that appears when the game has ended that prompts you to restart.

## Audio

A sound will play on every correct key press and a different, less pleasant sound will play on every incorrect key press. Whether there will be background music is up for discussion.

## Resources

QTE Script sourced and made by Kaiky Correa in a prior project

[Simple Flat Keys (Light/Dark)](https://gamedev-lab.itch.io/simple-flat-keys-lightdark) by [Gamedev Lab](https://gamedev-lab.itch.io) on itch.io
