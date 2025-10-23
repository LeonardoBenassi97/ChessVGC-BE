# ChessVGC-BE
Repository for the backend service of my new chess app with pokémon VGC rules

## Project Overview
A web application that manages chess games with unique rules and mechanics inspired by Pokémon VGC format.
The application is structured in two main stacks:
- Game Stack: Manages game events and text chat using SignalR and NoSQL database
- Statistics Stack: Handles game history and player statistics using REST APIs and relational database

## Unique Game Mechanics
- Dynamic turns based on piece speed:
  - Pawn: Speed 4
  - King: Speed 3
  - Queen: Speed 2
  - Rook, Bishop, Knight: Speed 1

- Two game modes:
  - Single: Each player submits one move
  - Double: Each player submits two moves

- Move resolution:
  - Moves are ordered by piece speed
  - White moves first in speed ties
  - In double mode, player's same-speed moves follow input order
  - Double mode restricts moving the same piece twice

- Cascade Validation System:
  1. Both players submit their moves simultaneously
  2. Moves are ordered by piece speed (higher speed first)
  3. Each move is validated using Stockfish engine
  4. If a piece is captured by a faster move, any subsequent moves involving that piece become illegal
     Example: If Black's Speed-4 Pawn captures White's Bishop, and White had planned a move with that Bishop (Speed-1),
     that move becomes illegal and is skipped in the resolution
  5. All remaining valid moves are executed in speed order

- Move Submission Process:
  1. Single Mode:
     - Each player submits one move
     - Moves are resolved based on piece speed
     - Faster pieces move first, regardless of player color
  
  2. Double Mode:
     - Each player submits two different moves
     - Same piece cannot be moved twice by the same player
     - Same type of piece can be moved twice (e.g., both knights)
     - Moves are resolved in speed order, with player's input order breaking ties

## Implementation Roadmap

### Phase 1: Data Models and Basic Structure ✓
1. Base Models:
   - Piece (with speed system)
   - Move (single and double handling)
   - Game (with board state)
   - Player (with User reference)
   - User and Statistics

2. Database Context:
   - Entity Framework Core setup
   - Relationship configurations
   - Data access patterns

### Phase 2: Core Game Logic
1. Chess Engine Service:
   - Stockfish integration
   - Base move validation
   - Speed calculation system
   - Cascade validation system

2. Game Manager:
   - Game creation and state management
   - Move application logic
   - Move ordering by speed
   - Game state updates

### Phase 3: SignalR Communication
1. Enhanced ChessHub:
   - Connection management
   - Game room management
   - Move broadcasting
   - Chat system implementation
   - Real-time game state updates

### Phase 4: REST API Layer
1. Controllers Implementation:
   - User management
   - Game history
   - Statistics tracking
   - Authentication system

### Phase 5: Database Implementation
1. NoSQL (MongoDB):
   - Active games schema
   - Current state tracking
   - Performance optimization

2. SQL (Entity Framework):
   - User data
   - Game history
   - Statistics tracking
   - Data relationships

### Phase 6: Game Logic Validation
1. Move Validation Service:
   - Single move legality
   - Move conflict resolution
   - Priority system implementation
   - Double mode specific validation

## Tech Stack
- .NET 8
- SignalR for real-time communication
- Entity Framework Core for SQL database
- MongoDB for NoSQL database
- Stockfish for chess move validation
