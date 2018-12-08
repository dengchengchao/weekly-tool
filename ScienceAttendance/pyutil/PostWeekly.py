#!/usr/bin/env python
# -*- coding:utf-8-*-
'''
     python 3.5
     Retrieve weekly news by crawling company intranet
'''
import urllib
import http.cookiejar
import sys

post_url = ''
week_url = ''
sign_in_url = ''
weekly_url = ''

empty_value = ""
action_action = "-action"  # 签到还是填写周报
action_sbsj = "-sbsj"  # 上班时间
action_gznr = "-gznr"  # 工作内容
action_date = "-date"  # 时间 年月日
action_zgs = "-zgs"  # 总工时
action_user = "-user"  # 用户名
action_pwd = "-pwd"  # 密码
action_xmbh = "-xmbh"  # 项目编号


params = {
    action_action: empty_value,
    action_sbsj: empty_value,
    action_gznr: empty_value,
    action_date: empty_value,
    action_user: empty_value,  # 账号
    action_pwd: empty_value,  # 密码
    action_zgs: empty_value,  # 总工时
    action_xmbh: empty_value,  # 项目编号
}

action_sign = "sign"
action_weekly = "weekly"
action_test = "test"  # 测试python程序能够成功被调用


def get_cookie(user_name, pass_word):
    cookie_jar = http.cookiejar.CookieJar()
    cookie_process = urllib.request.HTTPCookieProcessor(cookie_jar)
    opener = urllib.request.build_opener(cookie_process)
    headers = {
        'Host': 'kq.thunisoft.com:8080',
        'User-Agent': 'Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:55.0) Gecko/20100101 Firefox/55.0',
        'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8',
        'X-Requested-With': 'XMLHttpRequest',
        'Refere': ''
    }
    post_data = {
        'jusername': user_name,
        'jpassword': pass_word,
        'screen': '1600*900',
        'sysID': 'kqgl'
    }
    post_data = urllib.parse.urlencode(post_data).encode('utf-8')
    request = urllib.request.Request(post_url, post_data, headers)
    opener.open(request)
    return cookie_jar


# 签到
def sign_in(user_name, pass_word, date, sbsj):
    cookie_jar = get_cookie(user_name, pass_word)
    opener = urllib.request.build_opener(urllib.request.HTTPCookieProcessor(cookie_jar))
    headers = {
        'Host': '',
        'User-Agent': 'Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:55.0) Gecko/20100101 Firefox/55.0',
        'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8',
        'Referer': ''
    }
    post_data = {
        'action': 'runItemScript',
        'aty_parseId': '',
        'formType': '1',
        'kqglKqQjxx.bh': '',
        'org.springframework.web.servlet.HandlerMapping.pathWithinHandlerMapping': '/form/kqglKqQjxxDetail/insert',
        'org.springframework.web.servlet.HandlerMapping.bestMatchingPattern': '/form/{formId}/{rtt}',
        'itemid': 'jqButtonQD',
        'eventName': 'onClickServer',
        'sbsj': sbsj,  # '09:00',
        'data': date,  # 2018-06-29
        'zgs': '0'
    }
    post_data = urllib.parse.urlencode(post_data).encode('utf-8')
    request = urllib.request.Request(sign_in_url, post_data, headers)
    result_html = opener.open(request).read().decode('utf-8')
    print(result_html)


# 填写周报
def fillin_weekly_report(user_name, pass_word, data, xmbh, sbsj, zgs, gznr):
    cookie_jar = get_cookie(user_name, pass_word)
    opener = urllib.request.build_opener(urllib.request.HTTPCookieProcessor(cookie_jar))
    headers = {
        'Host': '',
        'User-Agent': 'Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:55.0) Gecko/20100101 Firefox/55.0',
        'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8',
        'Referer': ''
    }
    postdata = {
        'action': 'runItemLogic',
        'dataText': data,
        'data': data,
        'kqglKqRb.gznr': gznr,
        'kqglKqRb.zcgsText': zgs,
        'kqglKqRb.zcgs': zgs,
        'kqglKqRb.xgxm': xmbh,
        'kqglKqRb.rzlx': '1',
        'kqglKqRb.bh': '',

        'aty_parseId': '35469400a1907435b9eab0b8048090e3',
        'formType': '1',
        'kqglKqQjxx.bh': '',
        'org.springframework.web.servlet.HandlerMapping.pathWithinHandlerMapping': '/form/kqglKqQjxxDetail/insert',
        'org.springframework.web.servlet.HandlerMapping.bestMatchingPattern': '/form/{formId}/{rtt}',
        'itemid': 'jqFormAreaTxrb',
        'cloneId': 'jqButtonSave_AcloneA_da1c4',
        'buttonItemid': 'jqButtonSave',
        'method': 'parseFormSubmit',
        'dateTime': data,
        'sbsj': sbsj,  # 2018-06-29
        'zgs': zgs
    }
    postdata = urllib.parse.urlencode(postdata).encode('utf-8')
    request = urllib.request.Request(weekly_url, postdata, headers)
    result_html = opener.open(request).read().decode('utf-8')
    print(result_html)


def main_param():
    for index in range(len(sys.argv)):
        if index % 2 != 0:
            params[sys.argv[index]] = sys.argv[index + 1]
    # print(params)
    action = params[action_action]
    if action == action_sign:
        sign_in(params[action_user], params[action_pwd], params[action_date], params[action_sbsj])
    elif action == action_weekly:
        gznr = " " if params[action_gznr] == "#" else params[action_gznr]
        fillin_weekly_report(params[action_user], params[action_pwd], params[action_date], params[action_xmbh],
                             params[action_sbsj], params[action_zgs], gznr)
    elif action == action_test:
        print("success")


# mian`````
# 签到     python PostWeekly.py -action sign -user [用户名] -pwd [密码] -date [年月日：eg.2018-11-11] -sbsj [上班时间 eg.09:22]
# 填写周报  python PostWeekly.py -action weekly -user [用户名] -pwd [密码] -date [年月日：eg.2018-11-11] -sbsj [上班时间 eg.09:22] -gznr [工作内容] -zgs [总工时] -xmbh [项目编号]
main_param()
