public class TrieNode{
    private TrieNode[] children;
    public bool isWord;

    public TrieNode(int radix){
        children = new TrieNode[radix];
        isWord = false;
    }

    public TrieNode Next(int idx){
        return children[idx];
    }

    public TrieNode[] Children(){
        return children;
    }
}
public class Trie{
    private int R;
    private func<char, int> _charToIndex;
    private func<int, char> _indexToChar;
    private TrieNode root;

    public Trie(Alphabet alphabet){
        _charToIndex = alphabet._charToIndex;
        _indexToChar = alphabet._indexToChar;
        R = alphabet.R;
        root = new TrieNode();
    }

    public void Insert(string s){
        Insert(root, s, 0);
    }

    // . in s represents: match any character
    public bool Search(string s){
        var node = Search(root, s, 0);
        if(node == None || node.isWord == false) return false;
        return true;
    }

    public IList<string> KeysThatMatch(string s){
        var ret = new List<string>();
        CollectAllKeys(node, "", s, ret);
    }

    public IList<string> KeysWithPrefix(string s){
        // first, search the string s. Reuse code.
        var ret = new List<string>();
        var node = Search(root, s, 0);
        // collect all keys under a node.
        CollectAllKeys(node, s, ret);
        return ret;
    }

    public string LonestPrefix(string s){
        var len = LonestPrefix(root, s, 0, 0);
        return s.SubStr(0, len);
    }

    public void Delete(string s){
        root = delete(root, s, 0);
    }

    public int Size(){
        return Size(root);
    }

    private TrieNode delete(TrieNode node, string s, int idx){
        if(node == None) return None;
        if(idx == s.Count()){
            node.isWord = false;
        }
        else{
            var i = CharToIndex(s[idx]);
            node.next(i) = delete(node.next(i), s, idx+1);
        }

        if(node.isWord) return node;
        foreach(var child in node.Children()){
            if(child != None) return node;
        }
        return None;
    }

    private void LonestPrefix(TrieNode node, string s, int idx, int len){
        if(node == None) return;
        if(node.isWord) len = idx;
        if(idx == s.Count()) return len;

        LonestPrefix(node.next(CharToIndex(s[idx])), s, idx+1, len);
    }

    private void Insert(TrieNode root, string s, int idx){
        if(idx == s.Count()) {
            root.isWord = true;
            return;
        }
        var i = CharToIndex(s[idx]);
        if(root.next(i) == None) root.next(i) = new TrieNode;
        Insert(root.next(i), s, idx+1);
    }

    private TriNode Search(TrieNode root, string s, int idx){        
        if(root == None) return None;
        if(idx == s.Count()) return root;
        if(s[idx] == '.'){
            foreach (var child in root.Children()){
                var ret = Search(child, s, idx+1);
                if(ret != None) return ret;
            }
            return None;
        }
        else{
            return Search(root.next(CharToIndex(s[idx])), s, idx+1);
        }
    }

    // collect all keys under a node
    private void CollectAllKeys(TrieNode node, string s, IList<string> strs){
        if(node == None) return;
        if(node.isWord) strs.Add(s);
        for(var i = 0; i < R; i++){
            CollectAllKeys(node.next(i), s+IndexToChar(i), ret);
        }
    }

    //collect all keys under a node that match a pattern
    private void CollectAllKeys(TrieNode node, string s, string pat, IList<string> strs){
        var idx = s.Count();
        if(node == None) return;
        if(idx == pat.Count()){
            if(node.isWord) strs.Add(s);
            return;
        }
        if(pat[idx] == '.'){
            for(var i = 0; i < R; i++){
                CollectAllKeys(node.next(i), s+IndexToChar(i), pat, strs);
            }
        }
        else{
            CollectAllKeys(node.next(CharToIndex(pat[idx])), s+pat[idx], pat, strs);
        }
    }

    private char IndexToChar(int idx){
        return (char)idx;
    }

    private int CharToIndex(char c){
        return (int)c;
    }
    private int Size(TrieNode node){
        if(node == None) return 0;
        var count = 0;
        if(node.isWord) count++;
        foreach(var child in node.Children()){
            count += Size(child);
        } 
        return count;
    }
}