# FreenzyShoot 🔫

เกม **2D Action Platformer / Shooter** ที่สร้างด้วย Unity เป็นโปรเจคที่ทำตอนเรียน (student project)

ผู้เล่นบังคับตัวละครวิ่ง กระโดด ปีนบันได เก็บอาวุธและกุญแจ ยิงศัตรู หลบกับดัก แล้วหาทางไปให้ถึงประตูทางออกของแต่ละด่าน

---

## Tech Stack

| หัวข้อ | รายละเอียด |
|---|---|
| Engine | Unity **2020.3.38f1** (LTS) |
| ภาษา | C# (MonoBehaviour) |
| ระบบฟิสิกส์ | Unity 2D Physics (`Rigidbody2D`, `Collider2D`) |
| IDE | JetBrains Rider / Visual Studio (`FreenzyShoot.sln`) |

---

## วิธีเปิดโปรเจค (Getting Started)

1. ติดตั้ง **Unity Hub** และ **Unity 2020.3.38f1**
   > แนะนำให้ใช้เวอร์ชันนี้ตรง ๆ ถ้าเปิดด้วยเวอร์ชันอื่น Unity จะ upgrade โปรเจคให้ ซึ่งอาจทำให้ asset บางตัวพัง
2. เปิด Unity Hub → **Add** → เลือกโฟลเดอร์ `FreenzyShoot`
3. รอ Unity build `Library/` ให้เสร็จ (ครั้งแรกอาจใช้เวลาสักพัก)
4. เปิดซีน `Assets/Scenes/Menu.unity` แล้วกด **Play** ▶️

---

## การควบคุม (Controls)

| ปุ่ม | การทำงาน |
|---|---|
| `A` / `D` หรือ ลูกศร ซ้าย-ขวา | เดินซ้าย / ขวา |
| `Space` หรือ `W` | กระโดด (กระโดดได้เฉพาะตอนอยู่บนพื้น) |
| `W` / `S` (ตอนอยู่ที่บันได) | ปีนขึ้น / ลง |
| **คลิกซ้าย** | ยิง / โจมตี |
| `E` | ใช้สกิลของตัวละคร (มี cooldown) |

---

## ระบบในเกม (Game Systems)

### 🎮 Player
- เดิน / กระโดด / พลิกตัว (flip) ตามทิศทาง พร้อม Animator
- มีระบบ **HP** และ **HP Bar** แสดงผลบน UI
- เก็บ **HP Potion** เพื่อฟื้นฟูเลือด

### 🔫 Weapon System
เก็บอาวุธที่วางอยู่ในด่านได้ (`PickupWeapon`) โดยเก็บอาวุธใหม่จะสลับอาวุธเดิมทันที ปืนแต่ละกระบอกมีจำนวนกระสุนใน magazine ต่างกัน:

| อาวุธ | กระสุน (Ammo) |
|---|---|
| Sheriff | 8 |
| Classic | 7 |
| Odin | 50 |
| Bow | 5 |
| Sword | อาวุธระยะประชิด |

การยิงมี **cooldown** และกระสุนจะลดลงทีละนัด จำนวนกระสุนแสดงผลบน UI

### 👾 Enemy
- ศัตรูมีระบบ **aggro range** — ถ้าผู้เล่นเข้ามาใกล้ในระยะที่กำหนด ศัตรูจะวิ่งไล่ (`ChasePlayer`) ถ้าออกนอกระยะก็จะหยุดไล่
- มีระบบ HP + HP Bar ของศัตรู และตายเมื่อเลือดหมด
- มี **Wall HP** — กำแพงที่ต้องยิงทำลาย

### 🗝️ Key & Gate
- เก็บ **Key Item** ที่ซ่อนอยู่ตามด่าน (นับใน `GameVariable._keyCount`)
- ต้องเก็บกุญแจให้ครบ **4 ดอก** ประตู (`Gate`) ถึงจะเปิดผ่านไปได้

### ⚠️ Trap
- กับดักที่ทำให้เลือดลด (`Trap` — ลด HP 15 ต่อครั้ง)
- กับดักแบบร่วงหล่น (`TrapFall`)

### 🚪 Scene / Level Flow
- `DoorToNextLevel` — เดินชนประตูแล้วโหลดซีนถัดไปอัตโนมัติ
- `CheckReSpawn` — จุดเกิดใหม่เมื่อผู้เล่นตาย
- `Camerafollow` / `CameraMove` — กล้องเลื่อนตามผู้เล่น

---

## โครงสร้างซีน (Scene Flow)

```
Menu
 └─> Select Mission (Selecmission 1 / 2 / 3)
      └─> Select Character (Seleced Character / Stage1 / Stage2)
           └─> Mission Stages
                ├─ Tutoria      (ด่านสอนเล่น)
                ├─ Stage / Stage1-2
                └─ Stage2 / Stage2-1 / Stage2-2
```

มีตัวละครให้เลือกหลายแบบ แต่ละตัวมีสกิลของตัวเอง (`SkillPlayerBlue`, `SkillPlayerGreen`, `SkillPlayerBrown`)

---

## โครงสร้างโฟลเดอร์ (Project Structure)

```
FreenzyShoot/
├── Assets/
│   ├── Scenes/                 # ซีนทั้งหมดของเกม
│   │   ├── Menu.unity          # เมนูหลัก (เริ่มที่นี่)
│   │   ├── Mission/            # ด่านต่าง ๆ
│   │   ├── Select Mission/     # หน้าเลือกภารกิจ
│   │   └── Seleced Character/  # หน้าเลือกตัวละคร
│   │
│   ├── Scripts/                # โค้ดหลักของเกม
│   │   ├── Character/          # PlayerAttack, Shooting
│   │   ├── Enemy/              # Enemies, FollowPlayer, WallHp
│   │   ├── Weapon system/      # Gun, Magazine, PickupWeapon, DropWeapon
│   │   ├── Key/                # KeyItem, Gate, GameVariable
│   │   ├── Trap/               # Trap, TrapFall
│   │   ├── Hp/                 # HpBarEnemy, HpPotion
│   │   ├── Scene/              # Level, Mainmenu, DoorToNextLevel, CheckReSpawn
│   │   └── GamePlay/           # Ladder
│   │
│   ├── Script/                 # สคริปต์ชุดเก่า (Player, Bullet, Enemy, GameManager)
│   │
│   ├── Pixel Adventure 1/      # Asset ตัวละคร + tileset
│   ├── Sunnyland/              # Asset ฉาก
│   ├── 2D Background Builder - Russia/
│   └── AssetDownload/          # Asset ที่โหลดมาจาก Unity Asset Store
│
├── ProjectSettings/            # ตั้งค่าโปรเจค Unity
├── Packages/                   # Package dependencies
└── FreenzyShoot.sln            # Solution file สำหรับ IDE
```

> **หมายเหตุ:** มีโฟลเดอร์สคริปต์ 2 ชุดคือ `Assets/Script/` (ชุดเก่า) และ `Assets/Scripts/` (ชุดที่ใช้จริง) — ชุดเก่ายังเหลือไว้อยู่เพราะบางซีนยังอ้างถึง

---

## Credits

Art assets จาก Unity Asset Store:
- **Pixel Adventure 1** — ตัวละครและ tileset
- **Sunnyland** — ฉากและ environment
- **2D Background Builder - Russia**
- **BayatGames — Free Platform Game Assets**
- **Free 2D Adventure Beach Pack**

โค้ดเกมทั้งหมดเขียนเองเป็นส่วนหนึ่งของงานเรียน

---

## License

โปรเจคเพื่อการศึกษา (educational / student project) — art assets เป็นลิขสิทธิ์ของเจ้าของเดิมตามที่ระบุใน Credits
