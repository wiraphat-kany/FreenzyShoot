# _Unused — สคริปต์ที่ยังไม่ได้ใช้งาน

โฟลเดอร์นี้เก็บสคริปต์ที่ **ไม่มี scene หรือ prefab ไหนเรียกใช้ และไม่มีโค้ดอื่นอ้างถึง**
ย้ายมารวมไว้ที่นี่เพื่อให้ `Assets/Scripts/` เหลือเฉพาะโค้ดที่ทำงานจริง

> ⚠️ **ไฟล์ยังคอมไพล์อยู่นะครับ** — Unity คอมไพล์ทุกไฟล์ `.cs` ที่อยู่ใต้ `Assets/`
> ไม่ว่าจะอยู่โฟลเดอร์ไหน การย้ายมาที่นี่แค่ช่วยจัดระเบียบสายตา ไม่ได้ตัดออกจาก build
> ถ้าอยากตัดออกจริง ๆ ให้ลบทิ้ง (git เก็บประวัติไว้แล้ว กู้คืนได้)

---

## KeySystem/ — ระบบกุญแจ (เขียนเสร็จ แต่ยังไม่ได้ต่อเข้าเกม)

| ไฟล์ | หน้าที่ |
|---|---|
| `KeyItem.cs` | เก็บกุญแจ → `GameVariable._keyCount += 1` |
| `Gate.cs` | ประตูเปิดเมื่อ `_keyCount >= 4` |
| `GateLv2.cs` | ประตูเวอร์ชันด่าน 2 |
| `GameVariable.cs` | ตัวแปร static กลาง (`_keyCount`, `_amunition`) |

สคริปต์ 4 ตัวนี้อ้างถึงกันเองครบสมบูรณ์ แต่ **ไม่ได้ถูกแปะไว้กับ GameObject ใน scene ไหนเลย**
แปลว่าระบบกุญแจยังไม่ทำงานในเกม

**ถ้าจะทำต่อ:** ย้ายกลับไป `Assets/Scripts/Key/` แล้วใน Unity Editor ให้
แปะ `KeyItem` กับ object กุญแจ และแปะ `Gate` กับ object ประตู
(อย่าลืมตั้งชื่อ player object ว่า `Player` เพราะโค้ดเช็คด้วย `gameObject.name == "Player"`)

---

## สคริปต์อื่น ๆ ที่ไม่ได้ใช้

| ไฟล์ | หมายเหตุ |
|---|---|
| `PlayerAttack.cs` | ระบบยิงเวอร์ชันแรก — ถูกแทนที่ด้วย `Scripts/Character/Shooting.cs` ที่มี ammo + cooldown |
| `Enemies.cs` | ศัตรูเวอร์ชันที่มี aggro range — ของจริงที่ scene ใช้คือ `Script/Enemy.cs` |
| `WallHp.cs` | กำแพงมีเลือด — ยังไม่ได้วางใน scene |
| `Gun.cs` | ไฟล์เปล่า มีแต่ `Start()` / `Update()` ว่าง ๆ |
| `BulletData.cs` | data class ที่ไม่ได้ถูกเรียก |
| `FlipWeapon.cs` | เดิมวางอยู่ที่ root ของ `Assets/` |
| `CameraMove.cs` | กล้องเวอร์ชันเก่า — ของจริงคือ `Scripts/Camerafollow.cs` |
| `Mainmenu.cs` | เมนูเวอร์ชันซ้ำ — ของจริงที่ปุ่มเรียกคือ `Scripts/Scene/Level.cs` |
| `NewBehaviourScript.cs` | ไฟล์ default ที่ Unity สร้างให้ ไม่มีอะไรข้างใน |
