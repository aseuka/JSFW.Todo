# JSFW.Todo
일정 기록관리 (( 💙 내가 가장 애정을 가진 프로그램 중 하나! 💙 ))

목적 : 프로젝트 기간내 작업일정 관리 프로그램<br />
  프로젝트에 들어가서 내가 PL로부터 받은 작업지시와 관련된 파일과 메뉴들을 기록하고 완료 처리에 대한 기록을 남길수 있다.<br />
  SI에서 내 일정을 관리하는 중요한 프로그램이었다.<br />
  이걸 웹이나 모바일로 하고 싶긴한데... ( 물론 폐쇄망 같은 경우 파일은 어렵겠지만... 보안이슈도 있을꺼고... )<br />
  
  
= PL 이 일을 주는 상황1<br />
   1개의 화면에 어떤 작업을 해달라면서 엑셀 파일 1개를 보내준다. <br />
   
= PL 이 일을 주는 상황2<br />
   n개의 화면에 어떤 작업을 해달라면서 문서파일 n개를 보내준다. <br />
   
= 간혹 PL이 여럿인 그지같은 상황이 발생하기도 하다.<br />
   
   <br />
   
- 프로젝트 선택 화면<br />
![image](https://user-images.githubusercontent.com/116536524/198254281-69216ae2-d540-402a-9c15-559eac45dc45.png)


- 작업 하나를 등록, 작업에 필요한 첨부파일( 오른쪽 상단 [파일]탭 : 캡쳐가능, 파일드랍 가능 )<br />
![image](https://user-images.githubusercontent.com/116536524/198254510-e6cefb25-5854-4a3e-8532-1bf17cfd8a46.png)
![image](https://user-images.githubusercontent.com/116536524/198254673-7d9cfa10-f281-433d-b939-b4bfc3b1e77d.png)

- 작업중 메모 및 작업 분할 ( 사용하기 나름... )<br />
![image](https://user-images.githubusercontent.com/116536524/198255000-13d31498-5e73-4c3d-9f55-45b5faaebd84.png)

- 작업이력 <br />
![image](https://user-images.githubusercontent.com/116536524/198255141-99346974-c9eb-4ab1-b5ac-ba4b2df315d6.png)

- 메뉴별 이력<br />
![image](https://user-images.githubusercontent.com/116536524/198255193-d539cbdd-c329-4586-a7a9-9daf0e05bae5.png)

- 작업완료시 <br />
![image](https://user-images.githubusercontent.com/116536524/198255440-b6a24629-a254-431b-86f7-86d183aa14f3.png)




---
- 캡쳐 프로그램!<br />
[GreenShot](https://github.com/greenshot/greenshot)

 : 캡쳐 후 저장파일 경로를 이 프로그램에 맞추어 수정하여 dll만 참조<br />
   ( 필요시 git에서 다운받아 수정하여 사용. git에 소스를 올리면 안될 것 같아 dll만 참조 )<br />
 : WebBrowser 캡쳐 잘해주는 프로그램<br />
```diff
- 그린샷에서 log4net 사용하고 있으니 보안관련 확인이 필요함. 
- ( 전에 log4 관련 보안이슈가 있었는데... )
```
