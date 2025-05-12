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

Goal: Test if AR-enhanced vehicles appropriately yield to crossing pedestrians under AR signal cues.

Steps:

1. Initialize Environment:

Load the Unity scene with pedestrian agents, cars, and traffic signals.
Ensure ARKit and AR Foundation are active with crosswalk image markers placed on the physical layout.

2. Place Pedestrian Agents:

Instantiate animated pedestrians near crosswalks using AR-tracked image markers.
Assign FSM states: `Idle → Waiting → Crossing`.

3. Deploy Vehicles:

Spawn autonomous cars following spline-based Bezier paths using Rigidbody motion.

4. Activate AR Cues:

Display “Walk” and “Don’t Walk” AR overlays on crosswalks.
Trigger pedestrian FSM transition to “Crossing” when “Walk” signal is active.

5. Monitor Vehicle Behavior:

Use raycasting in front of cars to detect:

AR signal state
Pedestrian presence within 5 meters

6. Data Collection:

Log if car yields (stops) correctly.

Record:

Yield rate
Pedestrian response time to signal
Deviation from crosswalk path center
System latency (signal-to-response time)

2. Car Response to Traffic Signals:

Goal: Verify whether cars follow AR-anchored traffic signals appropriately.

Steps:

1. Load Simulation:

Set up intersections in Unity with animated traffic lights (Red, Yellow, Green).
Ensure markers anchor signals at appropriate physical locations.

2. Configure Vehicles:

Use raycasts to detect traffic lights ahead of each car.
Subscribe cars to global traffic light signal broadcasts.

3. Signal Cycling:

Program traffic lights using Unity's `Animator` or FSM logic to cycle states.

4. Define Car Reactions:

Green: continue motion
Yellow: decide based on proximity and speed
Red: decelerate and stop before the crosswalk line

5. Data Collection:

Measure:

Stop accuracy (distance from line)
Reaction time to each signal change
Compliance rate (correct response for each signal)


3. Pedestrian and Car Interaction Logic

Goal: Test how cars respond to real-time pedestrian actions at crosswalks, including edge cases.

Steps:

1. Initialize Pedestrian Logic:

   Place FSM-controlled pedestrian agents near crosswalks.
   Attach collider triggers to crosswalk zones.

2. Enable Car Listeners:

     Subscribe vehicles to pedestrian trigger events.
     Monitor pedestrian entry, exit, and position in real-time.

3. Execute Interaction Logic:

     If pedestrian is within crosswalk and signal is green:

     Car transitions to “Yield” or “Halt”

     If pedestrian reverses mid-crossing:

     Recalculate car path and FSM state

4. Synchronize via Events:

   * Use Unity’s event system to transmit crosswalk occupancy signals from pedestrians to cars.

5. Data Collection:

     Measure:

     Yield success rate
     Frequency of timing mismatches
     Edge case resolution success


4. Temporal Coordination and Reaction Chain Validation

Goal: Validate the timing sequence: signal → car reaction → pedestrian movement.

Steps:

1. Setup Timeline:

   Use Unity Timeline to control:

     Traffic light changes
     Pedestrian spawn and crossing
     Car path and speed

2. Add Micro Delays:

   Implement C# coroutines for realistic hesitation (e.g., ±0.3s).
   Simulate random delays in pedestrian response.

3. AR Anchor Synchronization:

   Ensure all events are triggered *after* AR markers (e.g., crosswalk image) are detected.

4. Log Event Timestamps:

   Record:

   Time of signal state change
   Car braking start time
   Pedestrian crossing initiation

5. Analyze Sequence Accuracy:

   Calculate:

   ΔT (car response after red signal)
   ΔT (pedestrian response after car stops)
   Deviations across trials (e.g., due to tracking jitter)

