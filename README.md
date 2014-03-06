
# Nocturnal
## GAME DESIGN DOCUMENT

### Vision Statement

With the growing convergence of consumer growth in medical and wearable technology the BRAINLINK brainwave sensor is setting itself up to become a powerful companion controller to the current generation of smart devices. However, their games are currently lacking in scope and growth. With the current BRAINLINK powered games focused on basic games centered around meditation, NOCTURNAL aims to target those players but in a more organic and challenging environment.* NOCTURNAL** *is a puzzle game for iOS and Android devices that utilizes the BRAINLINK personal brainwave sensor as an additional controller. Using problem solving, players must find their way in a magical forest switching between night and day to solve the puzzles that surround them. NOCTURNAL is focused on simplicity and meditative mechanics, with clean and simple aesthetics and little visual or auditory clutter.   

### Genre

*Puzzle, Platformer, Meditative*

Meditation at its core is an exercise in stillness, in quieting the mind to deeply reflect on life and your place in the world. The hope is that the repeated practice of focused introspection will help you to channel out the myriad distractions and manufactured dramas that seem to fill our lives.

Engaging in fast, repetitive, physical activities like running, bicycling, skating or skiing can trigger a sense of reflection by essentially separating physical selves from our mental processes. NOCTURNAL however, aims to target on focused relaxation, instead of approaching gameplay in a repetitive nature, it is designed to evoke reflection - using the BRAINLINK brainwave controller as a medium to measure the success.

### Game Concept

Each level in *NOCTURNAL* is actually two levels, one in which the physical objects scattered in  a daytime representation and night-time representation. The player can switch between the night and day worlds by alternating between focusing and meditation. 


Concept - *NOCTURNAL Day*


Concept - *NOCTURNAL Night*

### Game structure

#### Mechanics and Components

**_Meditation_***: Alpha wave (8-13hertz)***_  Focus_***: Beta wave (13-30 hertz)*

NOCTURNALS gameplay mechanics is based tightly around the BRAINLINK brainwave sensors ability to aggregate brain activity. As of such, the game itself requires the BRAINLINK brainwave sensor and will not work without it. However, it is not the sole input device for the player, only determining game states. They player can control their character using traditional input methods on their smart devices.

### Level Design

#### Overall Macrocalibration

Each level is built around one simple puzzle that can be completed in under a minute. (30 seconds to execute at most, 30 seconds for error and problem solving).  Each level will start in its daytime mode, this will not change as the levels progress. They then have one minute to find the orb on the other side of the screen. It can either be visible in the daylight or nighttime modes, but never both. At launch it’s planned to have 20 levels, with a difficulty ramp that has each level getting progressively harder over each second level.

#### Objective

An in world object placed in a difficult position to get to, that when touched by the player avatar will complete the level. Based of a numeral identity relationship, will add to the score. 

#### State

On / Off state between midnight and daylight. Based of a linear numerical relationship, where the conversion rate between two values is a constant. The states are a boolean based on the fuzzy feedback from the BRAINLINK brainwave sensor. There is a slight delay against the scale to reduce frustration with false readings from the sensor or momentary breaks in concentration.

### Gameplay

The gameplay is based on deterministic balance, all states in the game are predictable, leaving no variable to chance - this is to counter the fuzzy variables of the BRAINLINK brainwave sensor. This covers rules and equations, in if/else statements. The goal is to always produce the same state as a result of a given action. For any state that the game is in, you can find the winning state, this is however hidden within the puzzle system making it more challenging for the player, without making the game itself frustrating. These decisions improve trust between the player and the system; further expanded in Game Flow & Analysis: Reward Context.

### Player Actions and Turns

The player can control the character by using their phones touchscreen. Tap-holding the left will make the character move left, and tap-holding the right will respectfully do the same. Tapping any part of the screen will make the player jump.

Using the BRAINLINK personal brainwave sensor players can switch between daytime and night-time modes. With meditation being associated with daytime, and focus being night-time. The player will need to switch between the two modes two pass find and touch the glowing orb in the level.

When the player touches the orb they will see how well they performed using the BRAINLINK personal brainwave sensor analytics tools compared to the remaining time.

**Platform**

NOCTURNAL is designed to be played on the Android and iOS devices primarily for smartphones first. This focus puts less strain on development resources, and targets the goal for a game that can be played passively on the move. Players are more likely to have their smartphone on them then a tablet device

**Apple**

* iPhone: 320x480 | 3.5 in | 164ppi

* iPhone 4 | 960x640 | 3.5 in | 326ppi

* **iPhone 5 | ****1136 x 640 | 4in | ****326ppi**

* iPad 3 |  768 x 1024 | 9.7in | 264ppi

**Android**

* xLarge: 960dpx720dp | 320dpi

* **Large:  640dpx480dp | 240dpi**

* Normal: 470dpx320dp | 160dpi

* Small: 426dpx320dp | 120dpi

The BRAINLINK brainwave sensor is a required component for the game as core gameplay mechanics are built around the devices unique outputs. Using the devices API the game and smartphones will communicate with the BRAINLINK brainwave sensor via Bluetooth.

![image alt text](image_2.jpg)*Provided by Macrotellect*

### Players & Target Audience

Demographics: 

* Ages: 10+

* Genders: Both Genders

* Lifestyle: 

    * Exercise device for children to help them concentrate or meditate, simple rewards would appease them and the simple nature of the levels can generate an addictive exercise routine.

    * Meditative game for adults, the simple and short levels in the game means that it can be picked up and put down at any time during short breaks or routinely throughout the day.

Target Points:

* NOCTURNAL is an incredibly simple game that requires focus and meditation over skill or concentration it, therefore targets people who enjoy games that want simple rewards over a short period of investment.

* The simple nature of the game keeps people involved. There’s little frustration in keeping with the meditative nature of the game. This keeps each player involved throughout the game.

* Meditation and Focus are incredibly important for NOCTURNAL with it being a core interaction mechanic with the game.

* The lack of leaderboards or competitive competition means this is a game that challenges the player on their own terms.

### Key innovations

* The game is designed to be incredibly simple, with small puzzles introduced per level instead of multiple puzzles. Each level is designed to be beaten in under a minute at maximum further pushing the concept of simplicity. 

* Using the BRAINLINK personal brainwave sensor as an additional controller players will be ably to build up the focus / meditation skills as the game progresses, requiring them to alternate and maintain them to complete puzzles. 

* Biofeedback for controlling physical state

### Selling points

* **Easy & Simple**: The game focuses heavily on simple mechanics and gameplay with simple puzzles designed to be beaten in under a minute.

* **Personal Game**: The game has no competitive components, as its focus is more targeted towards personal achievements. 

* **Health Benefits**: The gameplay is designed to help people meditate and focus. 

* **Emerging Controls**: Uses the BRAINLINK brainwave sensor as a companion controller.

    * Combining the BRAINLINK brainwave sensor with traditional gameplay controls lowers the gameplay barrier.

    * Focus Training - players will see their focus improve as they play the game longer.

### Competitive Analysis

NOCTURNAL is very much a meditation game like BRAINLINKS current generation games, however it is differentiating from the genre of other meditation / puzzle games due to its higher level action and puzzle elements. While not an original concept itself as a platformer strategy, NOCTURNAL simplifies and extends the current BRAINLINK game genres while keeping them easy and accessible to the simplest denominations allowing it to easily be picked up by novices or those otherwise dissuade by brain powered games.

### Game Flow & Analysis

Fun stems from dealing with challenging situations and focus to achieve outcome. NOCTURNAL is built to utilize the BRAINLINK personal brainwave controller in an intuitive way, making it a core mechanic of the game, while keeping it from being an unintuitive or unnecessary component. By its nature it is designed to work with the game mechanics, and the players emotions. This drastically increase the replayability of games  

#### Player Experiences

As NOCTURNAL is a mind game it is focused on the interesting dynamics between focus and meditation in the players. As the player starts the game, they will be unaccustomed to the controller and how to properly meditate or focus. However as they progress throughout the game, they acquire personal real world skills in the form of meditative and focusing practice.

* Patience:  The meditative nature of the game forces players to focus their mind  in more practical ways, this develops as the game progresses giving them tangible skills.

* Confidence: Players will notice a change in their mind as they are better able to focus and meditate.

*Flow = Confidence + Relaxation + Coherence + Forward thrust - Boredom*

#### Reward Context

People feel they can trust the system and the reliability of their own actions to safely produce lasting results, they engage life much more positively. The focus is to generate presentism; uncritical adherence to present-day attitudes, especially the tendency to interpret past events in terms of modern values and concepts.

The game is designed to be extremely forgiving, in part to counter the difficulties of fuzzy input with the BRAINLINK brainwave sensor, and to formulate and strengthen trust between the player and the game system. With an amount of trust the player will be more likely to respond positively to game rewards both inside and outside the game. The player agency will also place greater motivation behind future and continual rewards. While NOCTURNAL will reward the players inside the game, the focus is to give the player a sense of accomplishment outside the game world itself. 

#### **Minor Rewards**

* Productivity: Players will blend the enjoyment of gaming with mind exercise.

* Relaxation: Players can experiment with a new technology in a fun and non-challenging environment.

#### **Major Rewards**

* Confidence: Players will notice a change in their mind as they are better able to focus and meditate.

### Variables Table

<table>
  <tr>
    <td>NOCTURNAL</td>
    <td>Freedom</td>
    <td>Mastery</td>
    <td>Data</td>
  </tr>
  <tr>
    <td>Action</td>
    <td>Small learning curve, non-challenging and forgiving environment</td>
    <td>Build up mind skills over the games course.</td>
    <td>Variety of moves, forced to be relatively different.</td>
  </tr>
  <tr>
    <td>System</td>
    <td>Relaxed and simple levels</td>
    <td>Different strategies and play styles.</td>
    <td>Great analytics, group sourcing</td>
  </tr>
  <tr>
    <td>Self</td>
    <td>Small rewards over time, build up tangible skills - meditation.</td>
    <td>Meditative Skills</td>
    <td>Winning the game!</td>
  </tr>
  <tr>
    <td>Social</td>
    <td>No social constraints</td>
    <td>No social constraints</td>
    <td>No social constraints</td>
  </tr>
</table>


# Design Approach 

Nocturnal is developed with the Top-Down Development approach, with ideas and concepts shaping the overall medium.

**Concept**: A game that helps players focus or meditate as they progress through the game. Developed with the BRAINLINK brainwave controller in a fashion that allows it to transcend a gimmicky fashion.

**Context**: A platformer game that allows the player to progress at their own pace.

**Content & Features**: A mystical forest with floating will-o-wisps that guide the player from level to level.

**Mechanics**: Use the brainwave controller to control game states without making it difficult for the player.

# Acknowledgments 

Lu David,

Co-founder, Chief Executive Officer.

Macrotellect Limited.

# References

Serviss, Ben. "In Search of Meditative Games." *Gamasutra*. Gamasutra, 21 Feb. 2013. Web. 25 Feb. 2014.

Sieks, David. "A Games as Art Meditation - from 1994." *Gamasutra*. Gamasutra, 16 May 2013. Web. 25 Feb. 2014.

Orland, Kyle. "Meditation Game For Kinect & Wii." *Gamasutra*. Gamasutra, 19 July2011. Web. 25 Feb. 2014.

Khandaker, Mitu. "Analysis: Games, Randomness And The Problem With Being Human." *Gamasutra*. Gamasutra, 5 May 2011. Web. 25 Feb. 2014.

Schreiber, Ian. "Game Balance Concepts." *Game Balance Concepts*. N.p., 7 July 2010. Web. 25 Feb. 2014.

