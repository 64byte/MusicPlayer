# MusicPlayer (C# Form)

> C# MusicPlayer for term project (2017)
  * C# Form Music Player with MS Access
    * MusicPlayer.mdb 파일을 통해 음악을 불러들여 재생하는 음악 플레이어입니다. 기능은 다음과 같습니다
      * 회원가입
      * 로그인
      * 재생/일시정지/뒤로감기/빨리감기
      * 음악 좋아요
      * 음악 검색

# Program routine
-----------------
<img src="https://github.com/64byte/MusicPlayer/blob/develop/resources/12.jpg"></img>

# Class UML
-----------------

 * Music UML

  <img src="https://github.com/64byte/MusicPlayer/blob/develop/resources/1.jpg"></img>

 * MusicList UML

  <img src="https://github.com/64byte/MusicPlayer/blob/develop/resources/2.jpg"></img>

 * MusicList UML

  <img src="https://github.com/64byte/MusicPlayer/blob/develop/resources/3.jpg"></img>

 * Database UML

  <img src="https://github.com/64byte/MusicPlayer/blob/develop/resources/4.jpg"></img>

# Source
-----------------
> Stack: C# (Form), MS Access

  - Form
    * Login Form: https://github.com/64byte/MusicPlayer/blob/develop/LoginForm.cs
    * Sign in Form: https://github.com/64byte/MusicPlayer/blob/develop/SignInForm.cs
    * Player Form: https://github.com/64byte/MusicPlayer/blob/develop/PlayerForm.cs

  - Control (Custom)
    * MediaTrackBar: https://github.com/64byte/MusicPlayer/blob/develop/Control/MediaTrackBar.cs
    * RoundButton: https://github.com/64byte/MusicPlayer/blob/develop/Control/RoundButton.cs
    * SeekBar: https://github.com/64byte/MusicPlayer/blob/develop/Control/SeekBar.cs
 
  - Database
    * https://github.com/64byte/MusicPlayer/blob/develop/Database/Database.cs
 
  - Music
    * Music (Model): https://github.com/64byte/MusicPlayer/blob/develop/Music/Music.cs
    * MusicList: https://github.com/64byte/MusicPlayer/blob/develop/Music/MusicList.cs
    * MusicPlayer: https://github.com/64byte/MusicPlayer/blob/develop/Music/MusicPlayer.cs
     
  - User (Model)
    * https://github.com/64byte/MusicPlayer/blob/develop/User/User.cs
 
  - Util
    * https://github.com/64byte/MusicPlayer/blob/develop/Util/Util.cs

# Implementation
-----------------

  * Main (메인 화면)
  
   <img src="https://github.com/64byte/MusicPlayer/blob/develop/resources/5.jpg"></img>
   
  * Sign in (가입 화면)
  
   <img src="https://github.com/64byte/MusicPlayer/blob/develop/resources/6.jpg"></img>
   
  * Signed in (가입 완료 화면)
  
   <img src="https://github.com/64byte/MusicPlayer/blob/develop/resources/7.jpg"></img>
   
  * Player Main (플레이어 메인)
  
   <img src="https://github.com/64byte/MusicPlayer/blob/develop/resources/8.jpg"></img>
   
  * Music Play (음악 재생 화면)
  
   <img src="https://github.com/64byte/MusicPlayer/blob/develop/resources/9.jpg"></img>
   
   
  * Music Like (좋아요를 누른 음악 목록)
  
   <img src="https://github.com/64byte/MusicPlayer/blob/develop/resources/10.jpg"></img>
   
   
  * Music Search (음악 검색)
  
   <img src="https://github.com/64byte/MusicPlayer/blob/develop/resources/11.jpg"></img>
   
## License
This project is released under the MIT public license.
