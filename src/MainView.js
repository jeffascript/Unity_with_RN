/**
 * Sample React Native App
 * https://github.com/facebook/react-native
 *
 * @format
 * @flow
 */

import React from 'react';
import {View, Text, TouchableOpacity} from 'react-native';

import tailwind from 'tailwind-rn';

const HomeScreen = ({navigation}) => {
  const onClick = () => {
    navigation.navigate('UnityScreen');
  };

  return (
    <View style={{height: 1000, backgroundColor: '#192879'}}>
      <View style={tailwind('container  px-6 text-center py-20')}>
        <Text
          style={tailwind('mb-6 text-4xl font-bold text-center text-white')}>
          Hello Gamer 👋 Welcome !!!
        </Text>
        <Text style={tailwind('my-5 text-2xl text-white  text-center ')}>
          A 3rd Person Shooter Game
        </Text>
        <Text style={tailwind('my-5 text-2xl text-white  text-center ')}>
          {`<= Jeff =>`}
        </Text>
      </View>

      <TouchableOpacity onPress={onClick}>
        <Text
          style={tailwind(
            'bg-white font-bold rounded-full  py-4 px-8  uppercase text-center mx-12',
          )}>
          Open Unity Player
        </Text>
      </TouchableOpacity>
    </View>
  );
};

export default HomeScreen;
