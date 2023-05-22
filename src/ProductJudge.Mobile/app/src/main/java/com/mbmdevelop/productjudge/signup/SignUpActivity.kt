package com.mbmdevelop.productjudge.signup

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import com.mbmdevelop.productjudge.R
import dagger.hilt.android.AndroidEntryPoint


@AndroidEntryPoint
class SignUpActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_sign_up)
    }
}