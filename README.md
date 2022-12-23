# 모기 헌터
+ ## 개임소개
> ### 무더운 여름 날 모기로 밤잠을 설치던 한 남자
> ### 꿈속에서 그토록 자신을 괴롭히던 모기를 사냥할 수 있게 된다.  

+ ## 개발중 발생된 문제점들
>**문제1** 에임 위치에 따라 플레이어 방향이 결정되도록 변경 필요.
>해결방법  
``` 
if(worldPos.x < this.transform.localPosition.x)  
        {  
            spriteRenderer.flipX = true;  
        }  
         if(worldPos.x > this.transform.localPosition.x)  
        {  
            spriteRenderer.flipX = false;  
        }  
```  
플레이어의 위치와 에임의 위치를 비교하고  
flipX이용하여 해결.  
  
---   
>**문제2** 모기의 플레이어 target방법으로 기존에는 플레이어 오브젝트를 인스펙터 창으로 끌어와 사용 그러나  
>prefab한 모기 오프젝트는 더 이상 플레이어를 드래그 앤 드롭으로 할당 받을 수 없게됨. 
>해결방법  
>>GameObject를 찾아주는 GameObject.Find() 를 이용하여 해결.  
  
---  
>**문제3** 플레이어의 총구 방향이 y축에서도 에임을 향하도록 수정 필요.
>해결방법  
>*아직 미해결*
  
---  
+ ## 게임방법  
> ### **짜증나는 모기를 잡으며 강해지자!**
> > 모기에게서 오래 살아남을 수록 **고혈압 게이지 상승**
> > 모기를 잡을 수록 **Coin Get**
> > 고혈압 게이지로 "Skill" 습득 가능  
> > Coin으로 각종 아이템 구매 가능
  
+ ## 미완성 게임 플레이 영상_2022/12/23기준
> ![playGif](https://user-images.githubusercontent.com/90640499/209385366-dc3794c6-3bf2-4c8e-b55f-716e9d2a1526.gif)

+ ## 타이틀 및 엔딩씬들
> <img width="50%" src="https://user-images.githubusercontent.com/90640499/209391311-981ea87f-6c64-4dd6-9494-1d10d4fe1075.png"/> 타이틀
--- 
> <img width="50%" src="https://user-images.githubusercontent.com/90640499/209391798-e55a7565-9d6f-4d6a-8fc4-ea33f3ec8a17.png"/> 승리
--- 
> <img width="50%" src="https://user-images.githubusercontent.com/90640499/209391802-d7abfdca-508c-4b01-bb46-c5ce4ad726d0.png"/> 패배
--- 
