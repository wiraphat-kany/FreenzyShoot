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

### ⚠️ Trap
- กับดักที่ทำให้เลือดลด (`Trap` — ลด HP 15 ต่อครั้ง)
- กับดักแบบร่วงหล่น (`TrapFall`)

### 🚪 Scene / Level Flow
- `DoorToNextLevel` — เดินชนประตูแล้วโหลดซีนถัดไปอัตโนมัติ
- `CheckReSpawn` — จุดเกิดใหม่เมื่อผู้เล่นตาย
- `Camerafollow` — กล้องเลื่อนตามผู้เล่น (ใช้ Cinemachine ร่วมด้วย)

### 🚧 ฟีเจอร์ที่ยังไม่เสร็จ
ระบบ **กุญแจ–ประตู** (เก็บกุญแจ 4 ดอกเพื่อเปิดประตู) เขียนโค้ดไว้ครบแล้ว
แต่ยังไม่ได้แปะเข้ากับ object ใน scene จึงยังไม่ทำงานในเกม
โค้ดอยู่ที่ `Assets/_Unused/KeySystem/` พร้อมวิธีต่อให้ใช้งานได้

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
│   ├── Script/                 # ⚠️ โค้ดหลักของตัวละคร (ใช้งานหนักที่สุด)
│   │   ├── Player.cs           #    ตัวผู้เล่น — ใช้ใน 12 scene
│   │   ├── HpBar.cs            #    หลอดเลือด — ใช้ใน 15 scene
│   │   ├── Bullet.cs           #    กระสุน
│   │   ├── Enemy.cs            #    ศัตรู
│   │   ├── GameManager.cs      #    ตัวคุมเกม
│   │   ├── PlayerManager.cs
│   │   └── Spawner.cs
│   │
│   ├── Scripts/                # โค้ดระบบรอบ ๆ เกม
│   │   ├── Character/          # Shooting (ระบบยิง + ammo)
│   │   ├── Enemy/              # FollowPlayer
│   │   ├── Weapon system/      # Magazine, PickupWeapon, DropWeapon
│   │   ├── Trap/               # Trap, TrapFall
│   │   ├── Hp/                 # HpBarEnemy, HpPotion
│   │   ├── Scene/              # Level, DoorToNextLevel, CheckReSpawn
│   │   ├── GamePlay/           # Ladder
│   │   ├── Camerafollow.cs
│   │   └── SkillPlayerBlue/Green/Brown.cs
│   │
│   ├── _Unused/                # สคริปต์ที่ไม่มี scene ไหนเรียกใช้ (ดู README ข้างใน)
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

> ⚠️ **จุดที่ต้องระวัง:** มีโฟลเดอร์สคริปต์ 2 ชุดชื่อคล้ายกันมาก คือ **`Script/`** (ไม่มี s)
> และ **`Scripts/`** (มี s) — **ใช้งานจริงทั้งคู่ ไม่ใช่ของเก่า/ของใหม่**
>
> `Script/` คือหัวใจของเกม (Player, HpBar, Bullet, Enemy) ส่วน `Scripts/` เป็นระบบรอบ ๆ
> เวลาแก้โค้ดให้ดูให้ดีว่าอยู่โฟลเดอร์ไหน
>
> ยังไม่ได้รวมเป็นชุดเดียวเพราะไฟล์เหล่านี้ถูกอ้างถึงในหลายสิบ scene
> ถ้าจะรวมในอนาคต **ให้ทำผ่าน Unity Editor** (ลากใน Project window) อย่าย้ายจาก File Explorer

---

## การทำงานร่วมกัน (Git)

โปรเจคนี้ใช้ git แล้ว โดยมี `.gitignore` ที่ตัดโฟลเดอร์ที่ Unity สร้างเองออก
(`Library/` ขนาด ~1.7 GB, `obj/`, `Logs/`, `UserSettings/`, ไฟล์ IDE)
โฟลเดอร์พวกนี้ **ไม่ต้อง commit** เพราะ Unity สร้างใหม่ได้เองตอนเปิดโปรเจค

### ข้อควรระวังเวลาทำงานกับเพื่อน ⚠️

1. **ห้ามลบ `.meta`** — Unity ใช้ไฟล์นี้จำว่า script ไหนแปะอยู่กับ object ไหน
   ถ้า `.meta` หาย scene จะขึ้น *"Missing script"* ทันที
2. **ย้าย/เปลี่ยนชื่อไฟล์ ให้ทำใน Unity Editor เสมอ** — ถ้าย้ายจาก File Explorer
   ต้องย้าย `.cs` กับ `.cs.meta` ไปด้วยกันเสมอ
3. **scene ไฟล์ merge ยาก** — พยายามอย่าให้สองคนแก้ scene เดียวกันพร้อมกัน
   ตกลงกันก่อนว่าใครทำด่านไหน

### คำสั่งพื้นฐาน

```bash
git status                  # ดูว่าแก้อะไรไปบ้าง
git add -A                  # เตรียม commit
git commit -m "ข้อความ"      # บันทึก
git log --oneline           # ดูประวัติ
```

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
