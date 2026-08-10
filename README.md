# SEEK-A-BOO

숨은 귀신 대 추리하는 퇴마사들 — 비대칭 멀티플레이 공포·추리 게임

저택에 숨은 귀신 1명과 퇴마사 최대 4명이 대결한다. 설치 없이 브라우저에서 바로 플레이할 수 있다.

| | |
|---|---|
| 플레이 | <https://cngjswns02.itch.io/seekaboo> |
| 플레이 영상 | <https://www.youtube.com/watch?v=eUNB1I9cjgQ> |
| 엔진 | Unity 6000.5.4f1 (URP) |
| 인원 | 2~5인 (귀신 1 · 퇴마사 최대 4) |
| 배포 | 웹 (WebGL, UGS Relay) |

---

## 게임 소개

귀신 한 명이 숨어 있는 저택에서, 퇴마사들이 흩어진 퇴마 도구를 찾아 귀신을 탐지하고 약점인 도구를 찾거나 추리해 퇴마하는 게임이다.

귀신이 누구인지는 처음부터 전원에게 공개된다. 이 게임이 감추는 것은 정체가 아니라 **귀신의 위치**와 **진짜 약점 도구**다. 저택 곳곳에 숨겨진 6종의 도구(카메라·십자가·성서·성수·탐지기·향초) 중 3종만이 귀신의 약점이며, 퇴마사는 도구를 찾아 귀신이 있을 만한 방향으로 사용해보며 약점을 찾거나 제단에 헌납한다.

반면 귀신은 본체와 영혼을 분리해 투명하게 돌아다니며 퇴마사에게 접근해 공포스킬을 걸어 현실화 게이지를 채운다. 게이지가 가득 차거나 조사 시간 내에 탐지를 당하지 않으면 귀신은 모습을 드러내고 제한 시간 동안 퇴마사를 사냥한다.

제단에 틀린 조합을 넣으면 무작위로 동료 한 명이 목숨을 잃는다. 협력과 리스크가 함께 걸린 추리가 이 게임의 핵심이다.

## 플레이 방법

### 승리 조건

퇴마사 (최대 4명)

- 맵에 숨겨진 도구를 찾아(인당 최대 4개 동시 소지) 귀신이 있을 곳을 추리해 사용한다 (시야 기반 탐지)
- 탐지에 3번 성공하거나, 제단에 올바른 약점 도구 3종을 헌납하면 승리
- 사냥 단계 시간이 끝날 때까지 한 명이라도 살아남으면 승리

귀신 (1명)

- 본체를 숨겨 위치와 약점을 들키지 않는다
- 영혼 상태로 이동하며 공포스킬로 현실화 게이지를 채운다
- 현실화 후 사냥 시간 안에 퇴마사를 전멸시키면 승리

### 조작

| 키 | 퇴마사 | 귀신 |
|---|---|---|
| WASD / 마우스 | 이동 / 시점 | 이동 / 시점 |
| Shift | 달리기 (×1.6) | 달리기 (×2.0) |
| Space | 점프 | 점프 |
| F | 도구 줍기 · 문 여닫기 · 제단 헌납 | — (문은 그냥 통과) |
| 좌클릭 | 도구 사용 | — |
| G | 도구 버리기 | — |
| 1~4 | 도구 슬롯 전환 | — |
| Q | — | 영혼 분리 / 복귀 |
| Ctrl | — | 조사: 영혼 흡수 · 사냥: 처형 |
| Tab(홀드) + 좌클릭 | 이모트 (3인칭 전환) | 이모트 (사냥 단계에만) |
| ` (백틱) | 메뉴 (설정 / 나가기) | 메뉴 (설정 / 나가기) |

메뉴 키로 ESC 대신 백틱을 쓰는 이유는, 브라우저가 ESC를 포인터 잠금 해제에 먼저 사용해 게임까지 전달되지 않기 때문이다.

### 진행 순서

```
은신 ──▶ 조사(탐지 · 제단) ──▶ 사냥 ──▶ 결과
          ▲                    │
          └── 탐지 성공(1~2번째)에 되감김 ──┘
```

탐지에 성공하면 어떤 도구였는지 전원에게 공개되고, 귀신은 다시 숨고 조사 시간은 가득 회복된다. 한 번 성공한 도구로는 다시 탐지할 수 없다. 세 번째 약점까지 밝혀내면 그 자리에서 퇴마사 승리다.

현실화 게이지가 100%가 되거나 조사 제한시간이 끝나면 사냥 단계로 넘어간다.

## 실행 방법

별도 설치가 필요 없다. 아래 링크를 브라우저에서 열면 바로 실행된다.

<https://cngjswns02.itch.io/seekaboo>

- 권장 환경: 데스크톱 브라우저 (Chrome / Edge 최신 버전). 모바일은 지원하지 않는다.
- 최초 접속 시 리소스를 내려받아 로딩에 다소 시간이 걸릴 수 있다.
- 소리는 브라우저 정책상 화면을 한 번 클릭한 뒤부터 재생된다.

### 혼자서 2인 플레이를 확인하는 방법

1. 위 링크에 접속해 닉네임을 입력하고 "방 만들기"를 누른다 (참가 코드가 발급된다)
2. 같은 링크를 새 브라우저 탭에서 한 번 더 연다
3. 두 번째 탭에서 닉네임을 입력하고, 발급받은 참가 코드로 "참가하기"를 누른다
4. 두 탭을 오가며 귀신·퇴마사 양쪽 진영을 조작해볼 수 있다

## 기술 스택

| 항목 | 내용 |
|---|---|
| 엔진 | Unity 6000.5.4f1, Universal Render Pipeline |
| 네트워킹 | Netcode for GameObjects 2.13.1 (서버 권한 모델) |
| 접속 | Unity Gaming Services Relay + Authentication (익명 로그인) |
| 입력 | Input System |
| 빌드 타겟 | WebGL (WebSocket 전용, 브라우저는 서버가 될 수 없어 Relay 필수) |

은닉 정보 게임이라 네트워크 설계가 축이다. 약점 3종은 `NetworkVariable`의 `ReadPermission.Owner`로, 탐지 결과는 `RpcTarget.Single`로 당사자에게만 보낸다. 데이터가 도착한 뒤 UI에서 가리는 방식은 쓰지 않는다.

## 저장소 구조

```
Assets/
  Scenes/          MainMenuScene(메인 메뉴·로비) → GameScene(저택·대기방·게임)
  Scripts/
    Core/          GameConfig, GamePhase, ToolType 등 공용 정의
    Game/          GameManager(상태 머신), Altar, RelayConnection, LobbyConsole
    Player/        이동·시점·역할 배정·애니메이션·랜턴
    Exorcist/      인벤토리, 상호작용
    Ghost/         본체/영혼 분리, 공포스킬
    Tools/         도구 스폰·월드 도구·탐지 판정
    UI/            메뉴·로비·HUD·결과·관전 (uGUI)
    Audio/         사운드 라이브러리와 재생
Docs/              기획·기술·진행 문서
Tools/             배포용 zip 패키징 스크립트
```

## 빌드

Unity 에디터에서 Build Profiles → Web → Build 로 `Build/` 폴더를 만든 뒤, 배포용 zip을 아래 스크립트로 만든다.

```bash
python Tools/pack_web_build.py
```

PowerShell의 `Compress-Archive`를 쓰면 안 된다. 경로 구분자를 역슬래시로 써서 itch.io가 폴더를 인식하지 못하고, 화면은 뜨는데 게임만 안 나오는 상태가 된다.

## 문서

| 문서 | 내용 |
|---|---|
| [ghost_game_scenario.md](Docs/ghost_game_scenario.md) | 게임 규칙, 단계 전이, 승리 조건, 밸런스 |
| [technical_design.md](Docs/technical_design.md) | 네트워크 구조, 조작 체계, 시스템별 구현 설계 |
| [functional_spec.md](Docs/functional_spec.md) | 검증 가능한 기능 단위 명세 |
| [ui_spec.md](Docs/ui_spec.md) | 화면 구성과 상호작용 |
| [setup_guide.md](Docs/setup_guide.md) | 씬 세팅과 테스트 절차 |
| [progress.md](Docs/progress.md) | 날짜별 작업 이력 |

## 만든 사람

3인 팀으로 개발했다.

| 이름 | 담당 역할 | 핵심 담당 영역 |
|---|---|---|
| 여지훈 | 프론트엔드 · UI/UX | 전체 UI 디자인, 화면·세부 창 구성 등 인터랙션 요소, 코드 연동 및 버튼·상호작용 구현 |
| 추헌준 | 백엔드 · 서버 · 배포 | 게임 내 기능 사전 개발, 서버 구현, 웹사이트 배포 |
| 장윤수 | 기획 · QA | 게임 기획, 품질 검증(QA) 및 테스트 |

기획, 개발, 검증의 단계별 분업으로 진행했다. 장윤수가 전체 기획을 수립하면 추헌준이 게임 내 핵심 기능과 서버 인프라를 구현하고, 여지훈이 UI를 설계해 앞서 구현된 기능들을 연동해 사용자가 조작하고 상호작용할 수 있는 프론트엔드 환경을 완성한다. 개발이 끝나면 백엔드 측에서 웹에 배포하고, 기획 측의 최종 QA로 품질을 검증한다.

## 외부 에셋 출처

### 모델

| 항목 | 제작자 (라이선스) | 링크 |
|---|---|---|
| 메인하우스 | Veterock (CC Attribution) | [sketchfab](https://sketchfab.com/3d-models/the-mansion-interiors-a6a788778bb047929c69a09621099e29) |
| 귀신 | LostBoyz2078 (CC Attribution-NonCommercial) | [sketchfab](https://sketchfab.com/3d-models/ghost-daughter-89850ac12e0f468582d4d0dcebd4efbc) |
| 퇴마사 | doublesob (CC Attribution-NonCommercial) | [sketchfab](https://sketchfab.com/3d-models/priest-c35fb2cd25b9451a824f1ef6ed10b847) |
| 십자가 | Seth Santos (CC Attribution) | [sketchfab](https://sketchfab.com/3d-models/wooden-cross-b19335b786ba49009f19a0a2d6a6afab) |
| 카메라 | meesvanhout (CC Attribution) | [sketchfab](https://sketchfab.com/3d-models/super-8-camera-canon-310xl-7218feba753b4b4bbdac135af36ac4a3) |
| 탐지기 | roganzu (CC Attribution) | [sketchfab](https://sketchfab.com/3d-models/bear-detector-stalker-fan-art-9d194a5f60cc4d478e2ccab40e007dfe) |
| 성수 | Ad_lolz (CC Attribution) | [sketchfab](https://sketchfab.com/3d-models/rdr1-holy-water-f788a35e028447a1ac50c4834dccae52) |
| 성서 | loafwad (CC Attribution) | [sketchfab](https://sketchfab.com/3d-models/bible-99acde3dfaff4c9bb590e986fb35a66b) |
| 제단 | LeeMoorhead (CC Attribution) | [sketchfab](https://sketchfab.com/3d-models/altar-76f57f7709274e37894a2a669a040aca) |
| 향초 | KaitlinKelly (CC Attribution) | [sketchfab](https://sketchfab.com/3d-models/candle-84a620c30bbc4bee8ce36d342debbad4) |
| 키오스크 | Martin Ibbett (CC Attribution) | [sketchfab](https://sketchfab.com/3d-models/scifi-kiosk-835aac31a9114203b5cb04952f9a273b) |

### 사운드

| 항목 | 제작자 (라이선스) | 링크 |
|---|---|---|
| 배경 사운드 | GWriterStudio (Unity Asset Store EULA) | [assetstore](https://assetstore.unity.com/packages/audio/ambient/horror-ambient-album-082318-127190) |
| 걷기, 뛰기 | Disagree (CC Attribution 4.0) | [freesound](https://freesound.org/people/Disagree/sounds/433725/) |
| 문 열기 | pagancow (CC0) | [freesound](https://freesound.org/people/pagancow/sounds/15419/) |
| 문 닫기 | soundmary (CC0) | [freesound](https://freesound.org/people/soundmary/sounds/117614/) |
| 스테이지 알림음 | juskiddink (CC Attribution 4.0) | [freesound](https://freesound.org/people/juskiddink/sounds/74920/) |
| 탐지 성공 | TheSoundFXGuy_YT (CC Attribution 4.0) | [freesound](https://freesound.org/people/TheSoundFXGuy_YT/sounds/534218/) |
| 탐지 실패 | dangthaiduy007 (CC0) | [freesound](https://freesound.org/people/dangthaiduy007/sounds/341670/) |
| 공포 갑툭튀 | jgriffie919 (CC Attribution-NonCommercial 3.0) | [freesound](https://freesound.org/people/jgriffie919/sounds/399855/) |
| 도구 줍기 | CosmicEmbers (CC Attribution 3.0) | [freesound](https://freesound.org/people/CosmicEmbers/sounds/160742/) |
| 제단 사운드 | TheSoundFXGuy_YT (CC Attribution 4.0) | [freesound](https://freesound.org/people/TheSoundFXGuy_YT/sounds/536595/) |
| 점프 | (CC0) | [freesound](https://freesound.org/people/deleted_user_2104797/sounds/325270/) |
| 킬 사운드 | SirBedlam (CC Attribution 3.0) | [freesound](https://freesound.org/people/SirBedlam/sounds/393824/) |

### 캐릭터 모션

| 제공 (라이선스) | 링크 |
|---|---|
| mixamo (Commercial & Non-Commercial) | <https://www.mixamo.com/> |

### 디자인

| 제작자 (라이선스) | 링크 |
|---|---|
| Katydid (CC Attribution) | [sketchfab](https://sketchfab.com/3d-models/horror-corridor-for-game-developers-15149d3c7eec478ca6c5d40e3c988fa4) |
| Alebardium (Extension Asset) | [assetstore](https://assetstore.unity.com/packages/2d/gui/bloodlines-dark-ui-328721) |
| GGBotNet (SIL Open Font License 1.1) | [dafont](https://www.dafont.com/help-me.font) |
| 주식회사 부크크 (상업적 이용 가능) | <https://bookk.co.kr/font> |
