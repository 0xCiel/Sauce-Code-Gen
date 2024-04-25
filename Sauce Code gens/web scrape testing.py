import requests
from bs4 import BeautifulSoup
url = 'https://nhentai.to/g/177013'
html = requests.get(url)

s = BeautifulSoup(html.content, 'html.parser')

results = s.find(id='info')
tag_results = s.find('section', id='tags')

INFO = results.find_all('h1')
TagInfo = tag_results.find_all('span', class_='name')

print(INFO[0].text)
for tag in tag_results:
    print(tag.text)