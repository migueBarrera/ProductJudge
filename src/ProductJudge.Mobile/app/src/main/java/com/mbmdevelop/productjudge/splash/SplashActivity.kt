package com.mbmdevelop.productjudge.splash

import android.annotation.SuppressLint
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import androidx.activity.viewModels
import com.mbmdevelop.productjudge.databinding.ActivitySplashBinding
import com.mbmdevelop.productjudge.singIn.SingInActivity
import dagger.hilt.android.AndroidEntryPoint

@AndroidEntryPoint
@SuppressLint("CustomSplashScreen")
class SplashActivity : AppCompatActivity() {
    private val viewModel: SplashViewModel by viewModels()

    private lateinit var binding: ActivitySplashBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivitySplashBinding.inflate(layoutInflater)
        setContentView(binding.root)

        checkIsLogin()

        observeIsLogin()
    }

    private fun checkIsLogin() {
        viewModel.checkIsLogin()
    }

    private fun observeIsLogin() {
        viewModel.getIsLogin().observe(this) { isLogin ->
            if (isLogin) {
                val intent = Intent(this, SingInActivity::class.java)
                intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP)
                startActivity(intent)
            } else {
                val intent = Intent(this, SingInActivity::class.java)
                intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP)
                startActivity(intent)
            }
        }
    }
}