class Random
{
    /**
     * 
     * @param {number} a 범위에 속한 최소의 정수
     * @param {number} b 범위에 속한 최대의 정수
     * @returns a이상 b이하의 임의의 정수를 반환한다.
     */
    static rand_int(a, b)
    {
        return a + Math.floor(Math.random() * (b - a + 1));
    }

    /**
     * 
     * @param {number} a 범위에 속한 최소의 실수
     * @param {number} b 최대 상한
     * @returns a이상 b미만의 임의의 실수를 반환한다.
     */
    static rand_float(a, b)
    {
        return a + (b - a) * Math.random();
    }

    /**
     * 각 면이 나올 확률이 1/m인 m면체 주사위를 n개 굴린 합을 반환한다.
     * @param {number} n 굴릴 주사위의 수 
     * @param {number} m 주사위 1개에 있는 면의 수
     * @returns m면체 주사위를 n개 굴린 합 반환
     */
    static dice_random(n, m)
    {
        let sum = 0;
        for (let i = 0; i < n; i++)
        {
            sum += this.rand_int(1, m);
        }
        return sum;
    }

    /**
     * 
     * @param {any[]} list 임의의 리스트 
     * @returns 리스트에 들어있는 요소 중 하나를 임의로 반환
     */
    static choice(list)
    {
        const size = list.length;
        return list[this.rand_int(0, size - 1)];
    }

    /**
     * 리스트 안의 요소의 순서를 섞는다.
     * @param {any[]} list 임의의 리스트 
     */
    static shuffle(list)
    {
        const size = list.length
        for (let i = size - 1; i > 0; i--)
        {
            const j = this.rand_int(0, i);
            
            const temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}

export {Random}