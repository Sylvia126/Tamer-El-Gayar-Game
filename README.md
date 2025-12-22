# 🎮 Gayar – Collecting Eggplants

---

## 📌 Game Overview

<p style="font-size:17px">
<strong>Gayar</strong> is a 3D third-person endless runner game developed using Unity.
The player controls a character named <strong>Gayar</strong>, running through a typical
Egyptian street while collecting eggplants and avoiding obstacles to achieve the
highest possible score.
</p>

---

## 🧠 Story

<p style="font-size:16px">
Gayar is a fast and clever character who loves eggplants. He runs through a busy
Egyptian street filled with road barriers, carts, cars, rocks, and unexpected objects.
The player must help Gayar dodge these obstacles while collecting as many eggplants
as possible.
</p>

---

## 🎯 Objectives & Gameplay Mechanics

- 🥬 **Collecting Items**  
  Collecting eggplants increases the player’s score and triggers visual effects.

- 🏃 **Movement**  
  Standard third-person movement using keyboard arrow keys.

- 🚧 **Obstacle Avoidance**  
  The main challenge is avoiding obstacles such as cars, rocks, and tomato packets.

- 💥 **Collision System**  
  Colliding with an obstacle triggers a physics-based falling and bouncing
  (ragdoll effect).

- ❌ **Game Over Condition**  
  The game ends immediately after a collision.

---

## 🛠️ Tools & Technologies

| Category | Tool / Technology |
|--------|------------------|
| Game Engine | Unity 2023 LTS (URP) |
| Programming Language | C# (.NET Framework) |
| 3D Modeling & Animation | Autodesk Maya 2024, Blender |
| Character Animations | Mixamo |
| Code Editor | Visual Studio 2022 |
| Version Control | Git & GitHub |
| Texture Editing | Adobe Photoshop / GIMP |

---

## 🎨 Graphics & Technical Features

### 💡 Lighting (URP)

- Baked Global Illumination for static environment objects  
- Real-time Directional Light simulating sunlight  
- Point Lights used to highlight eggplants as visual cues  

---

### 🎥 Camera System (Cinemachine)

- Cinemachine Free Look Camera  
- Follow & LookAt configured on the player character  
- Built-in camera collision to avoid visual obstruction  

---

### 🧱 Physically Based Rendering (PBR)

Each material uses:
- Albedo  
- Normal  
- Metallic  
- Roughness  
- Ambient Occlusion  

---

### 🎞️ Animations & Physics

- Animations created in Maya and imported using Mixamo  
- Animator Controller with state machine (Run, Crash)  
- Ragdoll system activated on collision  
- Animator re-enabled after respawn  

---

## ▶️ How to Run the Game

### Option 1: Run the Executable (Windows)

1. Open the GitHub repository  
2. Navigate to the **Build** folder  
3. Run the `.exe` file  

---

### Option 2: Run from Unity

1. Open the project using **Unity 2023 LTS**  
2. Load the main scene  
3. Press **Play ▶**  


---
## 📂 Project Structure

```
Gayar/
├── Assets/
├── Packages/
├── ProjectSettings/
├── Build/
└── README.md
```


---

## 🚀 Future Improvements

- Power-ups and new collectibles  
- Improved UI/UX  
- More sound effects and background music  
- Mobile version support  
- Online leaderboard system  

---

## 📜 License

<p style="font-size:15px">
This project was developed for <strong>educational purposes</strong>
as a university project.
</p>
