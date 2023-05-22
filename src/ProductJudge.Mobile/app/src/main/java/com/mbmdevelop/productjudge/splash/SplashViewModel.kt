package com.mbmdevelop.productjudge.splash

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import dagger.hilt.android.lifecycle.HiltViewModel
import javax.inject.Inject

@HiltViewModel
class SplashViewModel @Inject constructor(private val splashRepository: SplashRepository) : ViewModel() {

    private val isLogin = MutableLiveData<Boolean>()

    fun getIsLogin(): LiveData<Boolean> {
        return isLogin
    }

    fun checkIsLogin() {
        isLogin.value = false
    }
}