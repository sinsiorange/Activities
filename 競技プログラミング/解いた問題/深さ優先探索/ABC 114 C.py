# coding: utf-8
# Your code here!
N = int(input())
count = 0


def dfs(s):
    if int(s) > N: #�I������
        return 
    
    list = []
    for c in '753': #753��������
        if s.count(c) > 0:
            list.append(True)
        else:
            list.append(False)
    if all(list):
        global count 
        count += 1;
    
        
    for c in '753':
        dfs(s + c)
    
    return

dfs('0')
print (count)