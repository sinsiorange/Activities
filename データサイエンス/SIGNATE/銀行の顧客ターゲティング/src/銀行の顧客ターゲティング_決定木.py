import pandas as pd
import numpy as np
from matplotlib import pyplot as plt

from sklearn.tree import DecisionTreeClassifier as DT
from sklearn.model_selection import cross_validate
from sklearn.model_selection import GridSearchCV

train = pd.read_csv("C:/Users/yutar/OneDrive/ドキュメント/データサイエンス/SIGNATE/銀行の顧客ターゲティング/data/train.csv", engine = "python")
test = pd.read_csv("C:/Users/yutar/OneDrive/ドキュメント/データサイエンス/SIGNATE/銀行の顧客ターゲティング/data/test.csv", engine = "python")
sample = pd.read_csv("C:/Users/yutar/OneDrive/ドキュメント/データサイエンス/SIGNATE/銀行の顧客ターゲティング/data/submit_sample.csv", engine = "python", header = None)

trainX = train.iloc[:,0:17]
y = train["y"]
testX = test.copy()

#trainXとtestXをダミー変数化
trainX = pd.get_dummies(trainX)
testX = pd.get_dummies(testX)

#決定木モデルの箱を用意
clf = DT()
parameters = {"max_depth":list(range(2,11)),"min_samples_leaf":[5, 10, 20, 50, 100, 500]}
gcv = GridSearchCV(clf, parameters, cv = 5, scoring = "roc_auc", n_jobs = -1)
gcv.fit(trainX, y)
pred = gcv.predict_proba(testX)
pred = pred[:,1]
sample[1] = pred
sample.to_csv("C:/Users/yutar/OneDrive/ドキュメント/データサイエンス/SIGNATE/銀行の顧客ターゲティング/submit/submit_銀行の顧客ターゲティング_決定木.csv", index = None, header = None)
