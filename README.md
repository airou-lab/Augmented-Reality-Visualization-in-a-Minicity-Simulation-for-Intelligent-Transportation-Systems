Augmented Reality Minicity Simulation for Intelligent Transportation Systems

A semester-long research project demonstrating real-time, AR-enhanced simulations of pedestrian-vehicle interactions in a smart minicity. Built with Unity, ARKit, and Blender, this system enables spatially accurate, semantically rich testing of intelligent transportation behaviors using mobile augmented reality.

Project Highlights

- AR-Based Urban Simulation: Blend physical models with virtual agents using image marker-based anchoring.
- Pedestrian FSMs: Animated, state-driven pedestrian agents using NavMesh and event-based behavior logic.
- Autonomous Car Logic: Vehicles obey traffic signals and yield to pedestrians via raycasting and colliders.
- AR Traffic Signals: Real-time signal compliance and synchronization with agent movement.
- AR Safety Interfaces: Includes 9 tested AR overlays (e.g., Nudge HUD, Zebra Crossings) with user effectiveness scores.
- Built for Mobile: Optimized for iOS using Unity AR Foundation with ARKit.

Tech Stack

| Component       | Tool/Tech Used                      |
|----------------|--------------------------------------|
| Game Engine     | [Unity 2021.3 LTS](https://unity.com/releases/lts) |
| AR Framework    | AR Foundation + ARKit (iOS only)     |
| 3D Assets       | Blender (low-poly models, animations)|
| Programming     | C#, Unity Coroutines, Timeline       |
| Data Analysis   | Python (Pandas, SciPy), Unity Logs   |
| UI Design       | Unity Canvas, HUD, Line Renderer     |


Core Modules

- `Assets/Scripts/PedestrianController.cs`  
  Controls FSM for pedestrian states: Idle → Waiting → Crossing → Exited

- `Assets/Scripts/CarAgent.cs`  
  Autonomous car with signal logic, yield detection, and spline-based path following

- `Assets/Scripts/TrafficSignalFSM.cs`  
  Time-based signal controller with future hooks for event-driven transitions

- `Assets/Scripts/CentralLogicController.cs`  
  Coordinates state permissions between car, pedestrian, and signal (Week 13+)

- `Assets/AR/Scripts/ARPlacement.cs`  
  Plane detection and prefab instantiation using ARRaycastManager

Key Features

- Pedestrian and car agents move in sync with signal logic
- 9 visual AR safety interfaces (e.g., HUDs, fences, motion planes)
- Real-time collision and path coordination via Unity events
- Yielding logic + FSM coordination with event-based triggers
- Spatial alignment accuracy within ±2cm (via ARKit image tracking)

Results Summary

| Metric                   | Result             |
|--------------------------|--------------------|
| Yielding Accuracy        | 93%                |
| Pedestrian Delay (avg)   | 0.7s               |
| Frame Rate (max agents)  | 50–60 FPS          |
| Interface Top Performer  | Nudge HUD (+0.37)  |
| Least Effective          | Car Prediction (-0.52) |


Limitations

- Signal FSM is timer-based; event-driven version under development.
- No support for dynamic/stochastic behaviors (e.g., jaywalking).
- No multi-device cloud anchors; ARKit only (iOS).
- Limited scalability testing (>10 agents not yet benchmarked).

Project Timeline

| Week | Key Milestone |
|------|----------------|
| 1–3  | Unity + ARKit setup, plane detection, prefab placement |
| 4–6  | Pedestrian + bicycle FSM, waypoints, collision avoidance |
| 7–9  | Vehicle logic, signal FSM, AR interfaces designed/tested |
| 10–12| Full agent deployment in AR, spatial anchor testing |
| 13–14| Event-driven FSM coordination, metrics collection |
