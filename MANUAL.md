# ChristmasTree 메뉴얼

## 1. 프로젝트 개요

`ChristmasTree`는 WPF 기반의 데스크톱 애플리케이션입니다.  
투명한 전체 창 위에 크리스마스 트리 이미지를 표시하고, 눈 내림 효과를 함께 렌더링합니다.

주요 기능:

- 크리스마스 트리 이미지 표시
- 눈송이 애니메이션 재생
- 트리 이미지 드래그 이동
- 항상 위(`Topmost`)에 표시되는 투명 창

## 2. 개발 환경

- .NET 7.0
- WPF
- Windows 환경
- Visual Studio 2022 이상 권장

프로젝트 파일:

- `ChristmasTree.sln`
- `ChristmasTree.csproj`

## 3. 실행 방법

### Visual Studio에서 실행

1. `ChristmasTree.sln` 파일을 엽니다.
2. 빌드 구성을 `Debug` 또는 `Release`로 선택합니다.
3. 실행(`F5`) 또는 디버그 없이 실행(`Ctrl+F5`)합니다.

### CLI에서 실행

아래 명령으로 빌드 및 실행할 수 있습니다.

```powershell
dotnet build ChristmasTree.sln
dotnet run --project ChristmasTree.csproj
```

참고:

- WPF 프로젝트이므로 Windows에서 실행해야 합니다.
- 로컬 환경에 .NET 7 SDK 및 Windows Desktop 개발 구성요소가 필요합니다.

## 4. 화면 구성

애플리케이션 시작 시 `App.xaml`의 `StartupUri` 설정에 따라 메인 창이 실행됩니다.

시작 진입점:

- `App.xaml`
- `Views/MainWindow.xaml`

메인 화면 구성:

- 배경이 투명한 전체 창
- `Tree.png` 이미지 출력
- `SnowFall` 사용자 컨트롤을 통한 눈 애니메이션 출력

## 5. 주요 파일 설명

### 앱 시작

- `App.xaml`
  애플리케이션 시작 경로를 정의합니다.

- `App.xaml.cs`
  앱 클래스 코드 비하인드입니다.

### 메인 화면

- `Views/MainWindow.xaml`
  메인 윈도우 UI를 정의합니다.

- `Views/MainWindow.xaml.cs`
  메인 윈도우의 이벤트 처리 로직이 들어 있습니다.
  현재 로드 시 트리 이미지를 드래그 가능하도록 설정합니다.

### 눈 효과

- `Controls/SnowFall.xaml`
  눈 효과를 그릴 캔버스가 포함된 사용자 컨트롤입니다.

- `Controls/SnowFall.xaml.cs`
  `SnowEngine`을 생성하고 눈 내림을 시작합니다.

- `ViewModels/SnowEngine.cs`
  눈송이 생성, 이동, 제거를 담당하는 핵심 엔진입니다.

- `ViewModels/SnowInfo.cs`
  개별 눈송이의 상태 정보를 저장합니다.

### 드래그 기능

- `ViewModels/Drag.cs`
  이미지 드래그 이동을 위한 Attached Property 및 마우스 이벤트 로직을 제공합니다.

### 리소스

- `Resources/Tree.png`
  트리 이미지

- `Resources/snow1.png` ~ `Resources/snow9.png`
  눈송이 이미지

- `Ico/App.ico`
  애플리케이션 아이콘

## 6. 동작 방식

### 6.1 트리 표시

`Views/MainWindow.xaml`에서 `Image` 컨트롤로 `Tree.png`를 출력합니다.

### 6.2 눈 내림 효과

`SnowFall` 컨트롤 생성 시 `SnowEngine`이 초기화됩니다.  
이후 `Start()`가 호출되며 `CompositionTarget.Rendering` 이벤트를 통해 프레임 단위로 눈송이를 갱신합니다.

처리 흐름:

1. 눈송이 이미지 목록을 로드합니다.
2. 캔버스 크기에 따라 최대 눈송이 수를 계산합니다.
3. 눈송이를 생성합니다.
4. 각 프레임마다 X/Y 좌표를 이동시킵니다.
5. 화면 아래로 벗어난 눈송이는 제거합니다.

### 6.3 트리 드래그 이동

`MainWindow`가 로드되면:

1. `Drag.SetWindow(this)` 호출
2. `Drag.SetDrag(Tree, true)` 호출

이후 트리 이미지를 마우스로 드래그하여 이동할 수 있습니다.

## 7. 리소스 경로 주의사항

현재 `Controls/SnowFall.xaml.cs`의 눈송이 이미지 경로는 절대 경로로 작성되어 있습니다.

예:

```csharp
"C:\\Users\\John\\Documents\\GitHub\\ChristmasTree\\Resources\\snow1.png"
```

이 방식은 다른 PC 또는 다른 사용자 계정에서 경로가 달라질 경우 동작하지 않을 수 있습니다.

권장 방식:

- WPF 리소스(`pack://application`) 사용
- 실행 파일 기준 상대 경로 사용
- 프로젝트 리소스 클래스를 통한 접근 사용

## 8. 유지보수 시 확인할 사항

### 8.1 현재 확인된 미참조 코드

정적 참조 기준으로 아래 항목은 현재 사용되지 않는 코드 후보입니다.

- `Views/MainWindow.xaml.cs`의 `snow` 필드
- `ViewModels/Drag.cs`의 `GetDrag()`
- `ViewModels/SnowEngine.cs`의 `StartAsync()`
- `ViewModels/SnowEngine.cs`의 `Stop()`
- `ViewModels/SnowEngine.cs`의 `MinRadius`
- `ViewModels/SnowEngine.cs`의 `MaxRadius`
- `ViewModels/SnowEngine.cs`의 `VerticalSpeedRatio`
- `Properties/Resources.Designer.cs`의 strongly-typed resource 접근자

이 항목들은 정리 전 실제 사용 계획을 먼저 확인한 뒤 삭제 여부를 결정하는 것이 좋습니다.

### 8.2 개선 권장 사항

- 눈송이 경로를 절대 경로에서 리소스 기반 경로로 변경
- 사용하지 않는 필드/메서드 정리
- `SnowEngine`의 설정값을 외부에서 쉽게 변경할 수 있도록 구조 개선
- 예외 처리 및 로그 보강
- 창 크기, 위치, 클릭 동작 등 사용자 옵션 추가 검토

## 9. 배포 전 체크리스트

- Windows 환경에서 정상 실행 확인
- 트리 이미지가 정상 표시되는지 확인
- 눈 애니메이션이 정상 동작하는지 확인
- 드래그 이동이 정상 동작하는지 확인
- 다른 PC에서도 리소스 경로 문제가 없는지 확인
- 아이콘 적용 여부 확인

## 10. 문제 발생 시 점검 순서

### 눈이 보이지 않을 때

- `SnowFall` 컨트롤이 메인 화면에 포함되어 있는지 확인
- 눈송이 이미지 경로가 현재 PC 기준으로 유효한지 확인
- `SnowEngine.Start()`가 호출되는지 확인

### 트리가 이동하지 않을 때

- `MainWindow.Loaded` 이벤트가 연결되어 있는지 확인
- `Drag.SetWindow(this)`가 호출되는지 확인
- `Drag.SetDrag(Tree, true)`가 호출되는지 확인

### 이미지가 보이지 않을 때

- `Resources/Tree.png` 파일 존재 여부 확인
- XAML `Source` 경로가 올바른지 확인
- 리소스 빌드 설정이 올바른지 확인

## 11. 권장 후속 작업

다음 작업을 순서대로 진행하는 것을 권장합니다.

1. 눈송이 이미지 절대 경로 제거
2. 미참조 코드 정리
3. README 또는 사용자 배포용 간단 사용설명서 추가
4. 빌드/실행 검증 환경 정리

