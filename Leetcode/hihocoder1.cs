public int Delete(int[] arr){
    var st = new Stack<int>();
    var ret = 0;
    var i = 0;
    var N = arr.Count();

    while(i < N){
        if(st.Count() == 0 || (arr[i]+st.Peek()) & 1 == 0){
            st.Push(arr[i]);

        }
        else{
            ret += 2;
            st.Pop();
        }
        i++;
    }
    return ret;
}