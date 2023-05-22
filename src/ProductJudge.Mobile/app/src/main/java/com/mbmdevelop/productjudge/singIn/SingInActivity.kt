package com.mbmdevelop.productjudge.singIn

import android.content.Intent
import android.content.IntentSender
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import androidx.activity.viewModels
import com.google.android.gms.auth.api.identity.BeginSignInRequest
import com.google.android.gms.auth.api.identity.Identity
import com.google.android.gms.auth.api.identity.SignInClient
import com.google.android.gms.common.api.ApiException
import com.google.firebase.auth.FirebaseAuth
import com.google.firebase.auth.ktx.auth
import com.google.firebase.ktx.Firebase
import com.mbmdevelop.productjudge.R
import com.mbmdevelop.productjudge.databinding.ActivitySingInBinding
import com.mbmdevelop.productjudge.databinding.ActivitySplashBinding
import com.mbmdevelop.productjudge.signup.SignUpActivity
import com.mbmdevelop.productjudge.splash.SplashViewModel
import dagger.hilt.android.AndroidEntryPoint

@AndroidEntryPoint
class SingInActivity : AppCompatActivity() {
    private val viewModel: SplashViewModel by viewModels()
    private lateinit var auth: FirebaseAuth
    private lateinit var binding: ActivitySingInBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivitySingInBinding.inflate(layoutInflater)
        setContentView(binding.root)
// Initialize Firebase Auth
        auth = Firebase.auth


        binding.signInButtonEnter.setOnClickListener {

        }

        binding.signInButtonRegister.setOnClickListener {
            val intent = Intent(this, SignUpActivity::class.java)
            intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP)
            startActivity(intent)
        }
    }
}