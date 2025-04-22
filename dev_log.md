## 2025.4.13

Creature 클래스의 버프를 적용하는 applyBuff에서 forEach를 사용해서 버프를 적용하려고 했는데, 

```js
this.buffSet.forEach(function (buff) {
    buff.applyBuff(this.stat);
});
```

이렇게 하니까 this가 undefined여서 오류가 났다.
forEach 안의 함수는 외부 변수를 볼 수 없기 때문에 this를 볼 수 없었던 것이다.
그래서 이 부분은 for을 사용해서 해결했다.

## 2025.4.22

JS의 export, import를 사용하면 다른 파일에서 외부 클래스의 속성을 볼 수 있게 된다!
vs code에서 다른 클래스의 속성이 보이지 않아 그 파일을 왔다가 갔다가 하는 수고가 있었는데,
export, import를 사용하면 