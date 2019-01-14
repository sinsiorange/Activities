import numpy as np
import pandas as pd
from matplotlib import pyplot as plt
from sklearn.linear_model import LinearRegression as LR

train = pd.read_csv("C:/Users/yutar/OneDrive/ドキュメント/データサイエンス/SIGNATE/お弁当の需要予測/data/train.csv", engine = 'python')
test = pd.read_csv("C:/Users/yutar/OneDrive/ドキュメント/データサイエンス/SIGNATE/お弁当の需要予測/data/test.csv", engine = 'python')
sample = pd.read_csv("C:/Users/yutar/OneDrive/ドキュメント/データサイエンス/SIGNATE/お弁当の需要予測/data/sample.csv", engine = 'python', header = None)

#datetimeを-で分けて新たなカラムyearとmonthをつくる
train['year'] = train['datetime'].apply(lambda x : x.split('-')[0])
train['month'] = train['datetime'].apply(lambda x : x.split('-')[1])
test['year'] = test['datetime'].apply(lambda x : x.split('-')[0])
test['month'] = test['datetime'].apply(lambda x : x.split('-')[1])

train['year'] = train['year'].astype(np.int)
train['month'] = train['month'].astype(np.int)
test['year'] = test['year'].astype(np.int)
test['month'] = test['month'].astype(np.int)

#とりあえずyearとmonthだけで学習
trainX = train[['year', 'month']]
testX = test[['year', 'month']]
y = train['y']

model1 = LR()
model1.fit(trainX, y)

pred = model1.predict(trainX)

#予測値(pred)と実測値(y)の差をみて，その差が大きいデータに共通する要素をみつける
train['pred'] = pred
train['res'] = train['y'] - train['pred']

#print(train.sort_values(by = 'res'))

def jisaku1(x):
    if x == 'お楽しみメニュー':
        return 1
    else:
        return 0

train['fun'] = train['remarks'].apply(lambda x : jisaku1(x))
test['fun'] = test['remarks'].apply(lambda x : jisaku1(x))

trainX = pd.get_dummies(train[['year', 'month', 'fun', 'temperature', 'week']])
testX = pd.get_dummies(test[['year', 'month', 'fun', 'temperature', 'week']])

model2 = LR()
model2.fit(trainX, y)
pred2 = model2.predict(testX)
sample[1] = pred2

sample.to_csv("C:/Users/yutar/OneDrive/ドキュメント/データサイエンス/SIGNATE/お弁当の需要予測/submit/submit_Lunchbox2.csv",index = None, header = None)
