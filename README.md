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
| AR Framework    | AR Foundation + ARKit (iOS only)  https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@5.0/manual/project-setup/install-arfoundation.html   |
| 3D Assets       | Blender (low-poly models, animations)
https://www.blender.org/download/|
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


This a step-by-step guide to carry out each of the four experiments of the AR mini-city project. These are written in a replicable, testbed-ready format for anyone looking to reproduce the results:

1. Pedestrian Crossing and Car Yielding Scenarios

Hardware Requirements:

AR-compatible device: iPhone XS or newer / iPad with A12 Bionic chip or later
Operating System (mobile): iOS 15.0 or later
Development machine: macOS Monterey (12.0) or later
Processor (Mac): Apple M1/M2 or Intel i5/i7 (2018 or newer)
RAM: Minimum 8 GB (16 GB recommended)
Physical testbed: ~3m x 3m area with printed crosswalk markers
Router/local network: For multiplayer sync or inter-device coordination

Software Requirements:

Unity 2021.3 LTS or newer (AR Foundation compatible)
AR Foundation (v5.0+ recommended)
ARKit XR Plugin
Xcode 14+
Bezier Path plugin or custom spline logic
FSM system (e.g., PlayMaker or custom state machine in C#)

Environment Setup:

Printed crosswalk image markers
Consistent indoor lighting
Sufficient AR camera view for reliable marker detection

2. Car Response to Traffic Signals

Hardware Requirements:

Same base hardware as above
Larger testbed area: For multiple intersections
Optional: Tripod for fixed-position camera tracking

Software Requirements:

Unity 2021.3 LTS or newer with AR Foundation and ARKit plugins
Custom traffic signal controller (scripted or Animator-driven)
Raycasting system in cars to detect virtual lights
Optional: Global signal event manager (script-based)

Environment Setup:

AR markers to anchor traffic lights
Physical layout with intersection mimicry
Aligned AR signals and printed layout
Stable, bright lighting for accurate marker tracking

3. Pedestrian and Car Interaction Logic

Hardware Requirements:

iPhone XS or newer (or iPad)
Dual-device setup optional (1 device for pedestrian, 1 for vehicle agent)
AR marker-enhanced crosswalk area

Software Requirements:

Unity 2021.3 LTS+ with AR Foundation
Collider zones and trigger events
FSM logic for both pedestrians and cars
Unity Event system or custom pub-sub system

Environment Setup:

Physical crosswalks with AR markers
Collider-enabled virtual zones aligned with spatial coordinates
Scripting or external triggers for pedestrian behavior

4. Temporal Coordination and Reaction Chain Validation

Hardware Requirements:

iPhone/iPad with ARKit (A12+ chip)
Optional: iPad Pro with LiDAR for higher spatial accuracy
Logging hardware: On-device or synced via network
Operating System: iOS 15+
Mac with M1/M2 chip or Intel i7 (macOS 12+)

Software Requirements:

Unity Timeline system
C# coroutines for timing and delays
AR marker-based triggers
Logging system: Unity Analytics or custom timestamp logger

Environment Setup:

Accurate AR anchor placement using calibrated markers
Well-lit and unobstructed space
Ability to observe and log movement clearly

System Used for Development and Testing:

Mobile Devices:
iPhone 13 (iOS 17.2)
iPad Pro 2021 with LiDAR (iOS 16.6)

Development Machine:
MacBook Pro 14" (Apple M1 Pro, 16 GB RAM, macOS Ventura 13.4)
Unity 2021.3.25f1 LTS
Xcode 14.
