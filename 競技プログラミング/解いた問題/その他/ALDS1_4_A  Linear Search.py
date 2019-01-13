# coding: utf-8
# Your code here!
n = int(input())
S = list(map(int, input().split()))
q = int(input())
T = list(map(int, input().split()))

def search(S, key, n):
    i = 0
    S.append(key)
    while(S[i] != key):
        i += 1
    if(i == n):
        S.pop()
        return 0
    else:
        S.pop()
        return 1


count = 0
for key in T:
    count += search(S, key, n)
print(count)
