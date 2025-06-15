![Player_idle](https://github.com/user-attachments/assets/1ec694a1-834f-476c-99c6-fa6f7b0eb89c)# 쓰레기 머학생 구구단 미니게임 (Unity TA 포트폴리오)

> 메타빌 TA 인턴 모집 공고에 맞춰 제작한  
> **"쓰레기 머학생 구구단 미니게임"** 포트폴리오 프로젝트입니다.  
> Unity 기반 UI 연출, 캐릭터 애니메이션, 씬 구성 역량을 중심으로 구성하였습니다.
---

## 🎮 프로젝트 개요

- **프로젝트명**: 쓰레기 머학생 구구단 미니게임
- **플랫폼**: PC (Unity 6000.0.50f1)
- **개발 환경**: Unity, Photoshop
- **작업 방식**: 씬 설계 / UI 연출 / 애니메이션 키프레임 구성 / 리소스 가공

---

## 🧩 씬 구성 요약

| 씬 이름       | 설명 | 스크린샷 |
|--------------|------|----|
| TitleScene    | 클릭 시 StageSelect 씬으로 전환되는 메인 화면 | ![TitleScene](https://github.com/user-attachments/assets/7e4b7aab-05fa-45c5-8606-6cdeee62fd8d) |
| StageSelect   | 스테이지 별 언락 상태, 별 표시, 포커스 강조 UI 포함 | ![StageSelect](https://github.com/user-attachments/assets/f616a457-2ed4-49de-b229-c9b35fe2870d) |
| GameScene     | 적 출현 → 문제 풀이 → 발사체 발사 → 결과 판정까지의 게임 핵심 씬 | ![Gameplay](https://github.com/user-attachments/assets/4ac6ccc8-3197-47b0-8d9a-05a73b64a943) |
| ResultPopup   | 성공/실패에 따른 별 출력 및 버튼 제공 (씬 전환 없이 팝업 처리) | ![Clear](https://github.com/user-attachments/assets/4f4a2c77-08ef-4283-92fc-fa7c2477e167)![Faild](https://github.com/user-attachments/assets/4a26573e-86a5-4882-917a-afef072b2b20) |
| PuasePoup      | 게임 진행중 일시 정지 기능 제공 |![Pause](https://github.com/user-attachments/assets/731fa4e8-629a-4934-98a5-044ac0011932)|

---

## 🖼️ 리소스 가공 예시
![Player_Layer](https://github.com/user-attachments/assets/046b3bca-fe3f-44c9-80a5-0b7feee62df8)![Player_Rigging](https://github.com/user-attachments/assets/c12fb339-a32c-4d50-8895-6c5f9f065031)
![Enemy_Layer](https://github.com/user-attachments/assets/03398c20-f5ee-4d63-b2c3-e980507bd4c4)![Enemy_Rigging](https://github.com/user-attachments/assets/a59b2d88-2cf2-4d9a-9b4f-395b7632f150)

- 생성형 AI로 제작된 캐릭터 리소스를 분리/보정 후 Unity에 적용
- 애니메이션 작업을 위해 요소(머리카락, 얼굴, 몸통, 팔, 다리등)를 수작업으로 레이어 분리
- 버튼, 패널, 배경 등의 UI 요소는 Photoshop을 통해 제작 및 보정
---

## 🎬 애니메이션 적용 예시

| 항목 | 구현 방식 | 스크린샷 |
|------|-----------|-----|
| 캐릭터 기본 상태 | Animator 기반 Idle / Throw 트리거 | ![Player_idle](https://github.com/user-attachments/assets/2f9bbf4d-a3be-4274-9e84-fb3ccc14bee6)![Player_throw](https://github.com/user-attachments/assets/1a069b2b-15eb-4f62-bb1b-fed90c2de9f1)![Enemy_walk](https://github.com/user-attachments/assets/bb400ce2-f216-4f2e-8e9d-ccf7748af9d6) |
| 버튼 클릭 | 색상 전환 + 입력 제한 타이밍 설정 |
| 발사체 연출 | Animation Event로 동기화된 타이밍 발사 + 포물선 궤적 구현 |![Projectile](https://github.com/user-attachments/assets/ca7f2817-d76e-41ea-af32-f9ee07d27e0c) |

---

## 🔧 기능 구현 요약

- Stage 선택에 따른 문제 수 및 보스 로직 분기
- 곱셈 문제 및 보기 랜덤 생성 + 4지선다 UI 구성
- 정답 선택 시 플레이어 애니메이션 후 발사체 발사
- Projectile은 포물선 궤적으로 자연스럽게 이동
- 결과는 팝업 형태로 처리되어 유저 흐름 유지
- 플레이 결과에 따라 별 개수 산정 및 저장

---

## 🏁 실행 방법

1. Unity에서 해당 프로젝트 열기
2. `TitleScene` 실행
3. 마우스로 클릭 → 게임 진행

---

## 📂 기타

- 작업 기간: 약 3일 (기획 + 제작 + 연출 포함)
- 주요 포커스: Unity UGUI 연출, 캐릭터 애니메이션, 리소스 가공 및 적용

---

