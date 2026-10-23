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

The main game loop is played using the W, A, S, and D keys. Players are tasked with pressing those keys sequentially corresponding to the sequence given on screen. Pressing an incorrect key will momentarily stop the player's ability to input key presses and cause a red flash.

### 2. Rounds

The game is structured using a rounds based system, the game progressively getting harder with each round. Each round will generate a random sequence of WASD directional keys for the player to press, the quantity starting at # at the first round and increasing by 1 each round.

## World

Currently, the prototype has no particular worldbuilding, narrative, or characters. Assets were chosen prioritizing usability and adaptability for use in other games. 

## Interface

The key press sequence is shown on screen using sprites of keyboard keys with the corresponding letter on them, the sprites ordered left to right. The next key to be pressed is highlighted to signal key press order and speed up visual processing for the player. The interface aside from the QTE sequence is very minimalistic, consisting of a simple white text timer at the top of the screen and white text that appears when the game has ended that prompts you to restart. Before a round has started, there's text in the top left to signal the round number.

## Audio

A clack sound will play on every correct key press and a record scratch will play on every incorrect key press. There is no music or voice audio.

## Resources

QTE Script sourced and made by Kaiky Correa in a prior project

[Simple Flat Keys (Light/Dark)](https://gamedev-lab.itch.io/simple-flat-keys-lightdark) by [Gamedev Lab](https://gamedev-lab.itch.io) on itch.io

[Controller & Keyboard Icons](https://vryell.itch.io/controller-keyboard-icons) by [Vyrell](https://vryell.itch.io) on itch.io
